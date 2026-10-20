using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa_Abc
{
    public class ClaRoles
    {
        public int RollID { get; set; }
        public string NombreRol { get; set; }

        private string connetionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";

        public List<ClaRoles> ObtenerRoles()
        {
            List<ClaRoles> roles = new List<ClaRoles>();
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT RollID, NombreRol FROM Roles", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClaRoles rol = new ClaRoles
                    {
                        RollID = (int)reader["RollID"],
                        NombreRol = reader["NombreRol"].ToString()
                    };
                    roles.Add(rol);
                }
            }
            return roles;
        }
    }
}
