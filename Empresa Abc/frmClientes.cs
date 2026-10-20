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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            dgvCliente.CellDoubleClick += dgvClientes_CellDoubleClick;
            this.Load += frmClientes_Load;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        public void CargarClientes()
        {
            List<claClientes> clientes = new claClientes().ObtenerClientes();
            dgvCliente.DataSource = clientes;
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCliente.Rows[e.RowIndex];
                txtClienteID.Text = row.Cells["ClienteID"].Value.ToString();
                txtNombreCliente.Text = row.Cells["NombreCliente"].Value.ToString();
                txtTipoCliente.Text = row.Cells["TipoCliente"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(row.Cells["Estado"].Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtClienteID.Clear();
            txtNombreCliente.Clear();
            txtTipoCliente.Clear();
            chkEstado.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClienteID.Text))
            {
                AgregarCliente();
            }
            else
            {
                EditarCliente();
            }
        }

        private void AgregarCliente()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
            {
                string query = "INSERT INTO Clientes (NombreCliente, TipoCliente, Estado) VALUES (@NombreCliente, @TipoCliente, @Estado)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreCliente", txtNombreCliente.Text);
                cmd.Parameters.AddWithValue("@TipoCliente", txtTipoCliente.Text);
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente agregado");
                CargarClientes();
                LimpiarCampos();
            }
        }

        private void EditarCliente()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
            {
                string query = "UPDATE Clientes SET NombreCliente=@NombreCliente, TipoCliente=@TipoCliente, Estado=@Estado WHERE ClienteID=@ClienteID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreCliente", txtNombreCliente.Text);
                cmd.Parameters.AddWithValue("@TipoCliente", txtTipoCliente.Text);
                cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked);
                cmd.Parameters.AddWithValue("@ClienteID", int.Parse(txtClienteID.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente actualizado");
                CargarClientes();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClienteID.Text))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
                {
                    string query = "DELETE FROM Clientes WHERE ClienteID=@ClienteID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ClienteID", int.Parse(txtClienteID.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente eliminado");
                    CargarClientes();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un cliente para eliminar");
            }
        }
        public void ConfigurarClientes(string opcion)
        {
            switch (opcion)
            {
                case "Agregar":
                    btnGuardar.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnEliminar.Enabled = false;
                    dgvCliente.Enabled = false;
                    break;

                case "Editar":
                    btnGuardar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnEliminar.Enabled = false;
                    dgvCliente.Enabled = true;
                    break;

                case "Eliminar":
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEliminar.Enabled = true;
                    dgvCliente.Enabled = true;
                    break;

                case "Listar":
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEliminar.Enabled = false;
                    dgvCliente.Enabled = true;
                    break;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            claClientes datos = new claClientes();
            string nombreCliente = txtBuscar.Text;
            dgvCliente.DataSource = datos.BuscarClientes(nombreCliente);
        }
    }
}
        


