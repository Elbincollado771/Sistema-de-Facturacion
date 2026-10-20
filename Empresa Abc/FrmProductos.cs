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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            dgvProducto.CellDoubleClick += dgvProducto_cellDoubleclick;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        public void CargarProductos()
        {
            List<claProducto> productos = new claProducto().ObtenerProductos();
            dgvProducto.DataSource = productos;


        }
        private void dgvProducto_cellDoubleclick (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducto.Rows[e.RowIndex];
                txtProductoID.Text = row.Cells["ProductoID"].Value.ToString();
                txtNombreProducto.Text = row.Cells["NombreProducto"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
                chkEstado.Checked =  Convert.ToBoolean(row.Cells["Estado"].Value);
            }
            
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtProductoID.Clear();
            txtNombreProducto.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoID.Text))
            {
                AgregarProducto();
            }
            else
            {
                EditarProducto();
            }
        }
        private void AgregarProducto()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
            {
                string query = "INSERT INTO Productos (NombreProducto, Precio, Stock, Estado) VALUES (@NombreProducto, @Precio, @Stock, @Estado)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreProducto", txtNombreProducto.Text);
                cmd.Parameters.AddWithValue("@Precio", int.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto agregado");
                CargarProductos();
                LimpiarCampos();
            }
        }
        private void EditarProducto()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
            {
                
                string query = "UPDATE Productos SET NombreProducto=@NombreProducto, Precio=@Precio, Stock=@Stock, Estado=@Estado WHERE ProductoID=@ProductoID";
                SqlCommand cmd = new SqlCommand(query, con);

               
                cmd.Parameters.AddWithValue("@NombreProducto", txtNombreProducto.Text);
                cmd.Parameters.AddWithValue("@Precio", int.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked);
                cmd.Parameters.AddWithValue("@ProductoID", int.Parse(txtProductoID.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto actualizado");
                CargarProductos();
                LimpiarCampos();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductoID.Text))  
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
                {
                    
                    string query = "DELETE FROM Productos WHERE ProductoID = @ProductoID";
                    SqlCommand cmd = new SqlCommand(query, con);

                   
                    cmd.Parameters.AddWithValue("@ProductoID", int.Parse(txtProductoID.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto eliminado");
                    CargarProductos();  // Vuelve a cargar la lista de productos después de la eliminación
                    LimpiarCampos();     // Limpia los campos de texto después de eliminar
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar");
            }
        }
        public void ConfigurarProductos(String opcion)
        {
            switch (opcion)
            {
                case "Agregar":
                    btnGuardar.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnEliminar.Enabled = false;
                    dgvProducto.Enabled = false;
                    break;

                case "Editar":
                    btnGuardar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnEliminar.Enabled = false;
                    dgvProducto.Enabled = true;
                    break;

                case "Eliminar":
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEliminar.Enabled = true;
                    dgvProducto.Enabled = true;
                    break;

                case "Listar":
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEliminar.Enabled = false;
                    dgvProducto.Enabled = true;
                    break;
            }            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            claProducto datos = new claProducto();
            string NombreProducto = txtBuscar.Text;
            dgvProducto.DataSource = datos.BuscarProductos(NombreProducto);
        }
    }
}
