using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa_Abc
{
    public partial class FrmFactura : Form
    {
        private String connectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";
        private string usuarioLogueado;
        private int facturaSeleccionadaID;

        public FrmFactura(string usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            txtUsuario.Text = usuarioLogueado;
            txtUsuario.ReadOnly = true;
            CargarClientes();
            CargarProductos();
            InicializarDgvVerFacturas();
            InicializarDataGridView();
            InicializarDgvDetalleFactura();

        }

        public void ConfigurarFacturacion(string TipoFacturacion)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tabPage);
            }
            switch (TipoFacturacion)
            {
                case "Nueva Factura":
                    tabControl1.TabPages.Add(tabNueva);
                    break;

                case "Ver Factura":
                    tabControl1.TabPages.Add(tabVer);
                    break;
            }
        }

        private void CargarClientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ClienteID, NombreCliente FROM Clientes";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbClienteID.Items.Add(new { Text = reader["NombreCliente"].ToString(), Value = reader["ClienteID"] });
                    }

                    cmbClienteID.DisplayMember = "Text";
                    cmbClienteID.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message);
                }
            }
        }

        private void CargarProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ProductoID, NombreProducto FROM Productos WHERE Stock != 0";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbProducto.Items.Add(new { Text = reader["NombreProducto"].ToString(), Value = reader["ProductoID"] });
                    }

                    cmbProducto.DisplayMember = "Text";
                    cmbProducto.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los productos: " + ex.Message);
                }
            }
        }

        private void InicializarDataGridView()
        {
            dgvFactura.Columns.Clear();

            dgvFactura.Columns.Add("Producto", "Producto");
            dgvFactura.Columns.Add("Cantidad", "Cantidad");
            dgvFactura.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvFactura.Columns.Add("Subtotal", "Subtotal");
        }

        private decimal ObtenerPrecioProducto(int productoID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Precio FROM Productos WHERE ProductoID = @ProductoID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductoID", productoID);

                return (decimal)cmd.ExecuteScalar();
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvFactura.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            txtTotal.Text = total.ToString("F2");
        }

        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            if (cmbClienteID.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            if (dgvFactura.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertFacturaQuery = "INSERT INTO Cabecera_Factura (Fecha, ClienteID, UsuarioID, Total) OUTPUT INSERTED.FacturaID VALUES (@Fecha, @ClienteID, @UsuarioID, @Total)";
                    SqlCommand cmdFactura = new SqlCommand(insertFacturaQuery, connection, transaction);
                    cmdFactura.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmdFactura.Parameters.AddWithValue("@ClienteID", (int)((dynamic)cmbClienteID.SelectedItem).Value);
                    cmdFactura.Parameters.AddWithValue("@UsuarioID", ObtenerUsuarioLogueado());
                    cmdFactura.Parameters.AddWithValue("@Total", decimal.Parse(txtTotal.Text));

                    int facturaID = (int)cmdFactura.ExecuteScalar();

                    foreach (DataGridViewRow row in dgvFactura.Rows)
                    {
                        if (row.IsNewRow) continue;  

                        string productoNombre = row.Cells["Producto"].Value?.ToString();
                        object cantidad = row.Cells["Cantidad"].Value;
                        object precioUnitario = row.Cells["PrecioUnitario"].Value;
                        object subtotal = row.Cells["Subtotal"].Value;

                        if (string.IsNullOrEmpty(productoNombre) || cantidad == null || precioUnitario == null || subtotal == null)
                        {
                            MessageBox.Show("Asegúrese de que todos los campos en la fila del producto estén completos.");
                            return;
                        }
 
                        int productoID = ObtenerProductoIDPorNombre(productoNombre);
                        if (productoID <= 0)
                        {
                            MessageBox.Show($"Producto no encontrado: {productoNombre}");
                            return;
                        }

                        string insertDetalleQuery = "INSERT INTO Cabecera_Detalle (FacturaID, ProductoID, Cantidad, PrecioUnitario, Subtotal) VALUES (@FacturaID, @ProductoID, @Cantidad, @PrecioUnitario, @Subtotal)";
                        SqlCommand cmdDetalle = new SqlCommand(insertDetalleQuery, connection, transaction);
                        cmdDetalle.Parameters.AddWithValue("@FacturaID", facturaID);
                        cmdDetalle.Parameters.AddWithValue("@ProductoID", productoID);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", (int)cantidad);
                        cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", (decimal)precioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@Subtotal", (decimal)subtotal);

                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Factura guardada con éxito.");
                    dgvFactura.Rows.Clear();
                    txtTotal.Clear();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar la factura: " + ex.Message);
                }
            }
        }

        private int ObtenerProductoIDPorNombre(string nombreProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductoID FROM Productos WHERE NombreProducto = @NombreProducto";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreProducto", nombreProducto);

                return (int)cmd.ExecuteScalar();
            }
        }

        private int ObtenerUsuarioLogueado()
        {
            return 1;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null && !string.IsNullOrEmpty(txtCantidad.Text))
            {
                try
                {
                    string producto = cmbProducto.Text;
                    int cantidad = int.Parse(txtCantidad.Text);
                    decimal precioUnitario = ObtenerPrecioProducto((int)((dynamic)cmbProducto.SelectedItem).Value);
                    decimal subtotal = cantidad * precioUnitario;

                    dgvFactura.Rows.Add(producto, cantidad, precioUnitario, subtotal);

                    CalcularTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar producto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto y especificar la cantidad.");
            }
        }
        private void InicializarDgvVerFacturas()
        {

            dgvVerFacturas.Columns.Clear();


            dgvVerFacturas.Columns.Add("FacturaID", "ID Factura");
            dgvVerFacturas.Columns.Add("Fecha", "Fecha");
            dgvVerFacturas.Columns.Add("NombreCliente", "Nombre del Cliente");
            dgvVerFacturas.Columns.Add("Total", "Total");
        }
        private void InicializarDgvDetalleFactura()
        {
            dgvDetalleFactura.Columns.Clear();

            dgvDetalleFactura.Columns.Add("NombreProducto", "Producto");
            dgvDetalleFactura.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleFactura.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalleFactura.Columns.Add("Subtotal", "Subtotal");
        }
        private void CargarFacturas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT f.FacturaID, f.Fecha, c.NombreCliente, f.Total " +
                                   "FROM Cabecera_Factura f " +
                                   "JOIN Clientes c ON f.ClienteID = c.ClienteID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    dgvVerFacturas.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvVerFacturas.Rows.Add(reader["FacturaID"], reader["Fecha"], reader["NombreCliente"], reader["Total"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las facturas: " + ex.Message);
                }
            }
        }
        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscarFactura.Text))
            {
                int facturaID;
                if (int.TryParse(txtBuscarFactura.Text, out facturaID))
                {
                    VerFactura(facturaID);
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID de factura válido.");
                }
            }
        }

        private void VerFactura(int facturaID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT fd.ProductoID, p.NombreProducto, fd.Cantidad, fd.PrecioUnitario, fd.Subtotal " +
                                   "FROM Cabecera_Detalle fd " +
                                   "JOIN Productos p ON fd.ProductoID = p.ProductoID " +
                                   "WHERE fd.FacturaID = @FacturaID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@FacturaID", facturaID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    dgvDetalleFactura.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvDetalleFactura.Rows.Add(reader["NombreProducto"], reader["Cantidad"], reader["PrecioUnitario"], reader["Subtotal"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles de la factura: " + ex.Message);
                }
            }
        }

        private void tabVer_Enter(object sender, EventArgs e)
        {
            CargarFacturas();
        }
    }
}

