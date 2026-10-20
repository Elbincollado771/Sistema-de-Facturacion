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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
            dgvUsuario.CellDoubleClick += dgvUsuarios_CellDoubleClick;
        }
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuario();
            CargarRoles();
            CargarDatosEnDataGridViewPermisos();
            dgvPermiso.CellDoubleClick += dgvPermiso_CellDoubleClick;
        }
        private void CargarRoles()
        {
            ClaRoles roles = new ClaRoles();
            List<ClaRoles> listaRoles = roles.ObtenerRoles();

             
            cmbRoll.DataSource = listaRoles; 
            cmbRoll.DisplayMember = "NombreRol";  
            cmbRoll.ValueMember = "RollID"; 
        }
        public void CargarUsuario()
        {
            List<ClaUsuario> usuarios = new ClaUsuario().ObtenerUsuario();
            dgvUsuario.DataSource = usuarios;
        }
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuario.Rows[e.RowIndex];
                txtUsuarioID.Text = row.Cells["UsuarioID"].Value.ToString();
                txtNombreUsuario.Text = row.Cells["NombreUsuario"].Value.ToString();
                txtContrasena.Text = row.Cells["Contrasena"].Value.ToString();
                cmbRoll.SelectedValue = row.Cells["RollID"].Value;
                cmbEstado.SelectedItem = (bool)row.Cells["Estado"].Value ? "Activo" : "Inactivo";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtUsuarioID.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            cmbRoll.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuarioID.Text))
            {
                AgregarUsuario();
            }
            else
            {
                EditarUsuario();
            }
        }
        private void AgregarUsuario()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
            {
                string consulta = "INSERT INTO Usuarios (NombreUsuario, Contrasena, RollID, Estado) VALUES (@NombreUsuario, @Contrasena, @RollID, @Estado)";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
                cmd.Parameters.AddWithValue("@RollID", cmbRoll.SelectedValue);
                cmd.Parameters.AddWithValue("@Estado", cmbEstado.SelectedItem.ToString() == "Activo" ? true : false);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario agregado");
                CargarUsuario();
                LimpiarCampos();
            }
            if (cmbRoll.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un rol válido.");
                return;
            }

            if (cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un estado válido.");
                return;
            }

        }
        private void EditarUsuario()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
            {
                string query = "UPDATE Usuarios SET NombreUsuario=@NombreUsuario, Contrasena=@Contrasena, RollID=@RollID, Estado=@Estado WHERE UsuarioID=@UsuarioID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreUsuario", txtNombreUsuario.Text);
                cmd.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
                cmd.Parameters.AddWithValue("@RollID", cmbRoll.SelectedValue);
                cmd.Parameters.AddWithValue("@Estado", cmbEstado.SelectedItem.ToString() == "Activo" ? true : false);
                cmd.Parameters.AddWithValue("@UsuarioID", int.Parse(txtUsuarioID.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario actualizado");
                CargarUsuario();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuarioID.Text))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
                {
                    string query = "DELETE FROM Usuarios WHERE UsuarioID=@UsuarioID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UsuarioID", int.Parse(txtUsuarioID.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario Eliminado");
                    CargarUsuario();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un producto para eliminar");
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ClaUsuario datos = new ClaUsuario();
            string nombreUsuario = txtBuscar.Text;
            dgvUsuario.DataSource = datos.BuscarUsuario(nombreUsuario);
        }

        private void dgvPermiso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPermiso.Rows[e.RowIndex];
                txtPermisoID.Text = row.Cells["PermisoID"].Value.ToString();
                txtDescripcion.Text = row.Cells["NombrePermiso"].Value.ToString();
            }
        }

        private void tabPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPermisos")
            {
                CargarDatosEnComboBoxPermisos();
              
            }
        }

        private void CargarDatosEnComboBoxPermisos()
        {
            var permisos = new ClaPermiso().ObtenerPermisos();
            cmbPermisos.DataSource = permisos;
            cmbPermisos.DisplayMember = "NombrePermiso";
            cmbPermisos.ValueMember = "PermisoID";
        }

        private void cmbPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPermisos.SelectedItem is ClaPermiso permiso)
            {
                txtPermisoID.Text = permiso.PermisoID.ToString();
                txtDescripcion.Text = permiso.NombrePermiso;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPermisoID.Text, out int permisoID) && !string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                GuardarPermiso(permisoID, txtDescripcion.Text);
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }

        private void GuardarPermiso(int permisoID, string nombrePermiso)
        {
            string connectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Permisos SET NombrePermiso = @NombrePermiso WHERE PermisoID = @PermisoID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NombrePermiso", nombrePermiso);
                    cmd.Parameters.AddWithValue("@PermisoID", permisoID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Permiso guardado exitosamente.");
        }
        private void CargarDatosEnDataGridViewPermisos()
        {
                List<ClaPermiso> permisos = new ClaPermiso().CargarPermisos();
                dgvPermiso.DataSource = permisos;
        }
        public void ConfigurarGestion(String TipoGestion)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tabPage);
            }
            switch (TipoGestion)
            {
                case "Usuario":
                    tabControl1.TabPages.Add(tabUsuario);
                    break;

                case "Permisos":
                    tabControl1.TabPages.Add(tabPermisos);
                    break;
                
            }
        }

        private void BtnBuscarPermiso_Click(object sender, EventArgs e)
        {
            string nombrePermiso = txtBuscar.Text;
            List<ClaPermiso> permisos = new ClaPermiso().BuscarPermiso(nombrePermiso);
            dgvPermiso.DataSource = permisos;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPermisoID.Text))
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True"))
                {
                    string query = "DELETE FROM Permisos WHERE PermisoID=@PermisoID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PermisoID", int.Parse(txtPermisoID.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Permiso eliminado");
                    CargarDatosEnDataGridViewPermisos();
                    LimpiarCamposPermiso();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un permiso para eliminar");
            }
        }
        private void LimpiarCamposPermiso()
        {
            txtPermisoID.Clear();
            txtDescripcion.Clear();
            cmbPermisos.SelectedIndex = -1;
        }        
    }
}

 
