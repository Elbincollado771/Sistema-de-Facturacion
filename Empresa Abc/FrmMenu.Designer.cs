namespace Empresa_Abc
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuclientes = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.EditarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.EliminarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.ListadoDeClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuproductos = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.editarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.listarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.menufacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuinformes = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuconfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.YellowGreen;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuclientes,
            this.menuproductos,
            this.menufacturacion,
            this.menuinformes,
            this.menuconfiguracion});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 781);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuclientes
            // 
            this.menuclientes.BackColor = System.Drawing.Color.OliveDrab;
            this.menuclientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarCliente,
            this.EditarCliente,
            this.EliminarCliente,
            this.ListadoDeClientes});
            this.menuclientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuclientes.ImageTransparentColor = System.Drawing.Color.OliveDrab;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(127, 36);
            this.menuclientes.Text = "Clientes ";
            // 
            // AgregarCliente
            // 
            this.AgregarCliente.BackColor = System.Drawing.Color.YellowGreen;
            this.AgregarCliente.ForeColor = System.Drawing.Color.Sienna;
            this.AgregarCliente.Name = "AgregarCliente";
            this.AgregarCliente.Size = new System.Drawing.Size(339, 40);
            this.AgregarCliente.Text = "Agregar Cliente";
            this.AgregarCliente.Click += new System.EventHandler(this.AgregarCliente_Click);
            // 
            // EditarCliente
            // 
            this.EditarCliente.BackColor = System.Drawing.Color.YellowGreen;
            this.EditarCliente.ForeColor = System.Drawing.Color.Sienna;
            this.EditarCliente.Name = "EditarCliente";
            this.EditarCliente.Size = new System.Drawing.Size(339, 40);
            this.EditarCliente.Text = "Editar Cliente";
            this.EditarCliente.Click += new System.EventHandler(this.EditarCliente_Click);
            // 
            // EliminarCliente
            // 
            this.EliminarCliente.BackColor = System.Drawing.Color.YellowGreen;
            this.EliminarCliente.ForeColor = System.Drawing.Color.Sienna;
            this.EliminarCliente.Name = "EliminarCliente";
            this.EliminarCliente.Size = new System.Drawing.Size(339, 40);
            this.EliminarCliente.Text = "Eliminar Cliente";
            this.EliminarCliente.Click += new System.EventHandler(this.EliminarCliente_Click);
            // 
            // ListadoDeClientes
            // 
            this.ListadoDeClientes.BackColor = System.Drawing.Color.YellowGreen;
            this.ListadoDeClientes.ForeColor = System.Drawing.Color.Sienna;
            this.ListadoDeClientes.Name = "ListadoDeClientes";
            this.ListadoDeClientes.Size = new System.Drawing.Size(339, 40);
            this.ListadoDeClientes.Text = "Listado de Clientes ";
            this.ListadoDeClientes.Click += new System.EventHandler(this.ListadoDeClientes_Click);
            // 
            // menuproductos
            // 
            this.menuproductos.BackColor = System.Drawing.Color.OliveDrab;
            this.menuproductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProductos,
            this.editarProductos,
            this.eliminarProductos,
            this.listarProductos});
            this.menuproductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproductos.ImageTransparentColor = System.Drawing.Color.OliveDrab;
            this.menuproductos.Name = "menuproductos";
            this.menuproductos.Size = new System.Drawing.Size(147, 36);
            this.menuproductos.Text = "Productos";
            // 
            // agregarProductos
            // 
            this.agregarProductos.BackColor = System.Drawing.Color.YellowGreen;
            this.agregarProductos.ForeColor = System.Drawing.Color.Sienna;
            this.agregarProductos.Name = "agregarProductos";
            this.agregarProductos.Size = new System.Drawing.Size(342, 40);
            this.agregarProductos.Text = "Agregar Productos ";
            this.agregarProductos.Click += new System.EventHandler(this.agregarProductos_Click);
            // 
            // editarProductos
            // 
            this.editarProductos.BackColor = System.Drawing.Color.YellowGreen;
            this.editarProductos.ForeColor = System.Drawing.Color.Sienna;
            this.editarProductos.Name = "editarProductos";
            this.editarProductos.Size = new System.Drawing.Size(342, 40);
            this.editarProductos.Text = "Editar Productos";
            this.editarProductos.Click += new System.EventHandler(this.editarProductos_Click);
            // 
            // eliminarProductos
            // 
            this.eliminarProductos.BackColor = System.Drawing.Color.YellowGreen;
            this.eliminarProductos.ForeColor = System.Drawing.Color.Sienna;
            this.eliminarProductos.Name = "eliminarProductos";
            this.eliminarProductos.Size = new System.Drawing.Size(342, 40);
            this.eliminarProductos.Text = "Eliminar Productos";
            this.eliminarProductos.Click += new System.EventHandler(this.eliminarProductos_Click);
            // 
            // listarProductos
            // 
            this.listarProductos.BackColor = System.Drawing.Color.YellowGreen;
            this.listarProductos.ForeColor = System.Drawing.Color.Sienna;
            this.listarProductos.Name = "listarProductos";
            this.listarProductos.Size = new System.Drawing.Size(342, 40);
            this.listarProductos.Text = "Listar Productos";
            this.listarProductos.Click += new System.EventHandler(this.listarProductos_Click);
            // 
            // menufacturacion
            // 
            this.menufacturacion.BackColor = System.Drawing.Color.OliveDrab;
            this.menufacturacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaFacturaToolStripMenuItem,
            this.verFacturaToolStripMenuItem});
            this.menufacturacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menufacturacion.ImageTransparentColor = System.Drawing.Color.OliveDrab;
            this.menufacturacion.Name = "menufacturacion";
            this.menufacturacion.Size = new System.Drawing.Size(162, 36);
            this.menufacturacion.Text = "Facturacion";
            // 
            // nuevaFacturaToolStripMenuItem
            // 
            this.nuevaFacturaToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.nuevaFacturaToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.nuevaFacturaToolStripMenuItem.Name = "nuevaFacturaToolStripMenuItem";
            this.nuevaFacturaToolStripMenuItem.Size = new System.Drawing.Size(288, 40);
            this.nuevaFacturaToolStripMenuItem.Text = "Nueva Factura ";
            this.nuevaFacturaToolStripMenuItem.Click += new System.EventHandler(this.nuevaFacturaToolStripMenuItem_Click);
            // 
            // verFacturaToolStripMenuItem
            // 
            this.verFacturaToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.verFacturaToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.verFacturaToolStripMenuItem.Name = "verFacturaToolStripMenuItem";
            this.verFacturaToolStripMenuItem.Size = new System.Drawing.Size(288, 40);
            this.verFacturaToolStripMenuItem.Text = "Ver Factura";
            this.verFacturaToolStripMenuItem.Click += new System.EventHandler(this.verFacturaToolStripMenuItem_Click);
            // 
            // menuinformes
            // 
            this.menuinformes.BackColor = System.Drawing.Color.OliveDrab;
            this.menuinformes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeDeVentasToolStripMenuItem,
            this.informeDeInventarioToolStripMenuItem,
            this.informeDeClientesToolStripMenuItem});
            this.menuinformes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuinformes.ImageTransparentColor = System.Drawing.Color.OliveDrab;
            this.menuinformes.Name = "menuinformes";
            this.menuinformes.Size = new System.Drawing.Size(140, 36);
            this.menuinformes.Text = "Informes ";
            // 
            // informeDeVentasToolStripMenuItem
            // 
            this.informeDeVentasToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.informeDeVentasToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.informeDeVentasToolStripMenuItem.Name = "informeDeVentasToolStripMenuItem";
            this.informeDeVentasToolStripMenuItem.Size = new System.Drawing.Size(369, 40);
            this.informeDeVentasToolStripMenuItem.Text = "Informe de ventas ";
            this.informeDeVentasToolStripMenuItem.Click += new System.EventHandler(this.informeDeVentasToolStripMenuItem_Click);
            // 
            // informeDeInventarioToolStripMenuItem
            // 
            this.informeDeInventarioToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.informeDeInventarioToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.informeDeInventarioToolStripMenuItem.Name = "informeDeInventarioToolStripMenuItem";
            this.informeDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(369, 40);
            this.informeDeInventarioToolStripMenuItem.Text = "Informe de inventario";
            this.informeDeInventarioToolStripMenuItem.Click += new System.EventHandler(this.informeDeInventarioToolStripMenuItem_Click);
            // 
            // informeDeClientesToolStripMenuItem
            // 
            this.informeDeClientesToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.informeDeClientesToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.informeDeClientesToolStripMenuItem.Name = "informeDeClientesToolStripMenuItem";
            this.informeDeClientesToolStripMenuItem.Size = new System.Drawing.Size(369, 40);
            this.informeDeClientesToolStripMenuItem.Text = "Informe de clientes";
            this.informeDeClientesToolStripMenuItem.Click += new System.EventHandler(this.informeDeClientesToolStripMenuItem_Click);
            // 
            // menuconfiguracion
            // 
            this.menuconfiguracion.BackColor = System.Drawing.Color.OliveDrab;
            this.menuconfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeUsuarioToolStripMenuItem,
            this.gestionDePermisosToolStripMenuItem});
            this.menuconfiguracion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuconfiguracion.ImageTransparentColor = System.Drawing.Color.YellowGreen;
            this.menuconfiguracion.Name = "menuconfiguracion";
            this.menuconfiguracion.Size = new System.Drawing.Size(193, 36);
            this.menuconfiguracion.Text = "Configuracion";
            this.menuconfiguracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gestionDeUsuarioToolStripMenuItem
            // 
            this.gestionDeUsuarioToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.gestionDeUsuarioToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.gestionDeUsuarioToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.OliveDrab;
            this.gestionDeUsuarioToolStripMenuItem.Name = "gestionDeUsuarioToolStripMenuItem";
            this.gestionDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(351, 40);
            this.gestionDeUsuarioToolStripMenuItem.Text = "Gestion de Usuario";
            this.gestionDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.gestionDeUsuarioToolStripMenuItem_Click);
            // 
            // gestionDePermisosToolStripMenuItem
            // 
            this.gestionDePermisosToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.gestionDePermisosToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.gestionDePermisosToolStripMenuItem.Name = "gestionDePermisosToolStripMenuItem";
            this.gestionDePermisosToolStripMenuItem.Size = new System.Drawing.Size(351, 40);
            this.gestionDePermisosToolStripMenuItem.Text = "Gestion de permisos";
            this.gestionDePermisosToolStripMenuItem.Click += new System.EventHandler(this.gestionDePermisosToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.YellowGreen;
            this.pictureBox1.Image = global::Empresa_Abc.Properties.Resources.recursos_naturales;
            this.pictureBox1.Location = new System.Drawing.Point(944, 557);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1188, 781);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Sienna;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuclientes;
        private System.Windows.Forms.ToolStripMenuItem menuproductos;
        private System.Windows.Forms.ToolStripMenuItem AgregarCliente;
        private System.Windows.Forms.ToolStripMenuItem EditarCliente;
        private System.Windows.Forms.ToolStripMenuItem EliminarCliente;
        private System.Windows.Forms.ToolStripMenuItem ListadoDeClientes;
        private System.Windows.Forms.ToolStripMenuItem agregarProductos;
        private System.Windows.Forms.ToolStripMenuItem editarProductos;
        private System.Windows.Forms.ToolStripMenuItem eliminarProductos;
        private System.Windows.Forms.ToolStripMenuItem listarProductos;
        private System.Windows.Forms.ToolStripMenuItem menufacturacion;
        private System.Windows.Forms.ToolStripMenuItem nuevaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuinformes;
        private System.Windows.Forms.ToolStripMenuItem informeDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDeInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuconfiguracion;
        private System.Windows.Forms.ToolStripMenuItem gestionDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDePermisosToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}