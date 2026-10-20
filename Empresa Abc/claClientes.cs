using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Empresa_Abc
{
    public class claClientes
    {
        public int ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public string TipoCliente { get; set; }
        public bool Estado { get; set; }

        private string connectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";

        public List<claClientes> ObtenerClientes()
        {
            List<claClientes> clientes = new List<claClientes>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ClienteID, NombreCliente, TipoCliente, Estado FROM Clientes", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claClientes cliente = new claClientes
                    {
                        ClienteID = (int)reader["ClienteID"],
                        NombreCliente = reader["NombreCliente"].ToString(),
                        TipoCliente = reader["TipoCliente"].ToString(),
                        Estado = (bool)reader["Estado"]
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public List<claClientes> BuscarClientes(string nombreCliente)
        {
            List<claClientes> clientes = new List<claClientes>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ClienteID, NombreCliente, TipoCliente, Estado FROM Clientes WHERE NombreCliente LIKE @NombreCliente";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreCliente", "%" + nombreCliente + "%");

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claClientes cliente = new claClientes
                    {
                        ClienteID = (int)reader["ClienteID"],
                        NombreCliente = reader["NombreCliente"].ToString(),
                        TipoCliente = reader["TipoCliente"].ToString(),
                        Estado = (bool)reader["Estado"]
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }
    }
}
