using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Empresa_Abc
{
    public class claProducto
    {
        public int ProductoID { get; set; }
        public String NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

        private String connectionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";
        public List<claProducto> ObtenerProductos()
        {
            List<claProducto> productos = new List<claProducto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductoID, NombreProducto, Precio, Stock, Estado FROM Productos", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claProducto producto = new claProducto
                    {
                        ProductoID = (int)reader["ProductoID"],
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Precio = (decimal)reader["Precio"],
                        Stock = (int)reader["Stock"],
                        Estado = (bool)reader["Estado"]

                    };
                   productos.Add(producto); 
                }
            }
            return productos;
        }
        public List<claProducto> BuscarProductos(string NombreProducto)
        {
            List<claProducto> productos = new List<claProducto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductoID, NombreProducto, Precio, Stock, Estado FROM Productos WHERE NombreProducto LIKE @NombreProducto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreProducto", "%" + NombreProducto + "%");

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claProducto producto = new claProducto
                    {
                        ProductoID = (int)reader["ProductoID"],
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        Estado = Convert.ToBoolean(reader["Estado"])

                    };
                    productos.Add(producto);
                }
            }
            return productos;
        }
    }
}
