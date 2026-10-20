using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Empresa_Abc
{
    public class claLogin
    {
        private string ConnectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";

        public int ValidarUsuario(String Usuario, String Contrasena)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT RolID FROM Usuarios WHERE NombreUsuario = @usuario AND Contrasena = @contrasena AND Estado = 1";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@usuario", Usuario);
                cmd.Parameters.AddWithValue("@contrasena", Contrasena);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error de Usuario: " + ex.Message);
                }
            }
        }
    }
}
