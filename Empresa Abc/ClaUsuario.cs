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
    public class ClaUsuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int RollID {  get; set; }
        public bool Estado { get; set; }

        private string connectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";

        public List<ClaUsuario> ObtenerUsuario()
        {
            List<ClaUsuario> usuarios = new List<ClaUsuario>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT UsuarioID, NombreUsuario, Contrasena, RollID, Estado FROM Usuarios", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaUsuario usuario = new ClaUsuario
                    {
                        UsuarioID = (int)reader["UsuarioID"],
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Contrasena = reader["Contrasena"].ToString(),
                        RollID = (int)reader["RollID"],
                        Estado = (bool)reader["Estado"]
                    };
                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }
        public List<ClaUsuario> BuscarUsuario(string nombreUsuario)
        {
            List<ClaUsuario> usuarios = new List<ClaUsuario>();
            using (SqlConnection con =new SqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, NombreUsuario, Contrasena, RolID, Estado FROM Usuarios WHERE NombreUsuario LIKE @NombreUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreUsuario", "%" + nombreUsuario + "%");
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaUsuario usuario = new ClaUsuario
                    {
                        UsuarioID = (int)reader["UsuarioID"],
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Contrasena = reader["Contrasena"].ToString(),
                        RollID = reader["RolID"] != DBNull.Value ? Convert.ToInt32(reader["RolID"]) : 0, 
                        Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : false
                    };
                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }
        
    }
}