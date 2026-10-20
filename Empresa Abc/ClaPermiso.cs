using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa_Abc
{
    public class ClaPermiso
    {
        public int PermisoID { get; set; }
        public string NombrePermiso { get; set; }

        private string connectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";

        public List<ClaPermiso> CargarPermisos()
        {
            List<ClaPermiso> permisos = new List<ClaPermiso>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PermisoID, NombrePermiso FROM Permisos";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaPermiso permiso = new ClaPermiso
                    {
                        PermisoID = (int)reader["PermisoID"],
                        NombrePermiso = reader["NombrePermiso"].ToString(),
                        
                    };
                    permisos.Add(permiso);
                }
            }

            return permisos;
        }
        public List<ClaPermiso> ObtenerPermisos()
        {
            List<ClaPermiso> permisos = new List<ClaPermiso>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT PermisoID, NombrePermiso FROM Permisos", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaPermiso permiso = new ClaPermiso
                    {
                        PermisoID = (int)reader["PermisoID"],
                        NombrePermiso = reader["NombrePermiso"].ToString()
                    };
                    permisos.Add(permiso);
                }
            }
            return permisos;
        }
        public List<ClaPermiso> BuscarPermiso(string nombrePermiso)
        {
            List<ClaPermiso> permisos = new List<ClaPermiso>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PermisoID, NombrePermiso FROM Permisos WHERE NombrePermiso LIKE @NombrePermiso";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombrePermiso", "%" + nombrePermiso + "%");

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaPermiso permiso = new ClaPermiso
                    {
                        PermisoID = (int)reader["PermisoID"],
                        NombrePermiso = reader["NombrePermiso"].ToString()
                    };
                    permisos.Add(permiso);
                }
            }
            return permisos;
        }

    }
}
