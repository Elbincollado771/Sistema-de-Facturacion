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
    public partial class FmInformes : Form
    {
        private string connetionString = @"Data Source=DESKTOP-F7LKE4Q\SQLEXPRESS;Initial Catalog=EmpresaAbc;Integrated Security=True";
        public FmInformes()
        {
            InitializeComponent();
            CargarVentas();
            CargarInventario();
            CargarClientes();
        }


        private void CargarVentas ()
        {
            using (SqlConnection con = new SqlConnection (connetionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT VentaID, FechaVenta, TotalVenta FROM dbo.Ventas", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVentas.DataSource = dt;
            }
        }
        private void CargarInventario()
        {
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductoID, NombreProducto, Stock FROM Productos", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInventario.DataSource = dt;
            }
        }
        private void CargarClientes()
        {
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ClienteID, NombreCliente, Estado FROM Clientes", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;
            }
        }

        public void  ConfigurarInformes(String TipoInforme)
        {
            foreach(TabPage tabPage in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tabPage);
            }
            switch(TipoInforme)
            {
                case "Ventas":
                    tabControl1.TabPages.Add(tpVentas);
                    break;

                case "Inventario":
                    tabControl1.TabPages.Add(tpInventarios);
                    break;
                case "Clientes":
                    tabControl1.TabPages.Add(tpClientes);
                    break;
            }
        }
    }
}
