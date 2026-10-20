using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa_Abc
{
    public partial class FrmMenu : Form
    {
        private int rolId;
        private string usuarioLogueado;
        public FrmMenu(int rolId, string usuarioLogueado)
        {
            InitializeComponent();
            this.rolId = rolId;
            ConfigurarMenuSegunRol();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void ConfigurarMenuSegunRol()
        {
            menuclientes.Visible = false;
            menuproductos.Visible = false;
            menufacturacion.Visible = false;
            menuinformes.Visible = false;
            menuconfiguracion.Visible = false;

            switch (rolId)
            {
                case 1:
                    menuclientes.Visible=true;
                    menufacturacion.Visible=true;
                    break;

                case 2:
                    menufacturacion.Visible=true;
                    break;

                case 3:
                    menuclientes.Visible = true;
                    menuproductos.Visible=true;
                    menufacturacion.Visible=true;
                    menuinformes.Visible=true;
                    break;

                case 4:
                    menuclientes.Visible=true;
                    menuproductos.Visible=true;
                    menufacturacion.Visible=true;
                    menuinformes.Visible = true;
                    menuconfiguracion.Visible = true;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        

        private void AgregarCliente_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.ConfigurarClientes("Agregar");
            frmClientes.Show();
        }

        private void EditarCliente_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.ConfigurarClientes("Editar");
            frmClientes.Show();
        }

        private void EliminarCliente_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.ConfigurarClientes("Eliminar");
            frmClientes.Show();
        }

        private void ListadoDeClientes_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.ConfigurarClientes("Listar");
            frmClientes.Show();
        }

        private void agregarProductos_Click(object sender, EventArgs e)
        {
            
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ConfigurarProductos("Agregar");
            frmProductos.Show();
        }

        private void editarProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ConfigurarProductos("Editar");
            frmProductos.Show();
        }

        private void eliminarProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ConfigurarProductos("Eliminar");
            frmProductos.Show();
        }

        private void listarProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ConfigurarProductos("Listar");
            frmProductos.Show();
        }

        private void informeDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmInformes frmInformes = new FmInformes();
            frmInformes.ConfigurarInformes("Ventas");
            frmInformes.Show();
        }

        private void informeDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmInformes frmInformes = new FmInformes();
            frmInformes.ConfigurarInformes("Inventario");
            frmInformes.Show();
        }

        private void informeDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmInformes frmInformes = new FmInformes();
            frmInformes.ConfigurarInformes("Clientes");
            frmInformes.Show();
        }

        private void gestionDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.ConfigurarGestion("Usuario");
            frmUsuario.Show();
        }

        private void gestionDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.ConfigurarGestion("Permisos");
            frmUsuario.Show();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura(usuarioLogueado);
            frmFactura.ConfigurarFacturacion("Nueva Factura");
            frmFactura.Show();
        }

        private void verFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura(usuarioLogueado);
            frmFactura.ConfigurarFacturacion("Ver Factura");
            frmFactura.Show();
        }        
    }
    
}
