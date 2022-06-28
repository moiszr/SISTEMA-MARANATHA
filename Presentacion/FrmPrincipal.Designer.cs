namespace Presentacion
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.Sidebar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClientes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCompras = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnVentas = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnUsuarios = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPagar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProductos = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnFacturacionRedito = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnFacturacionContado = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Navbar = new System.Windows.Forms.Panel();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.Salir = new System.Windows.Forms.PictureBox();
            this.Wrapper = new System.Windows.Forms.Panel();
            this.bntPagoF = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Navbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            this.SuspendLayout();
            // 
            // Sidebar
            // 
            this.Sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.Sidebar.Controls.Add(this.bntPagoF);
            this.Sidebar.Controls.Add(this.label1);
            this.Sidebar.Controls.Add(this.label5);
            this.Sidebar.Controls.Add(this.label4);
            this.Sidebar.Controls.Add(this.btnLogout);
            this.Sidebar.Controls.Add(this.btnClientes);
            this.Sidebar.Controls.Add(this.btnCompras);
            this.Sidebar.Controls.Add(this.btnVentas);
            this.Sidebar.Controls.Add(this.btnUsuarios);
            this.Sidebar.Controls.Add(this.btnPagar);
            this.Sidebar.Controls.Add(this.btnProductos);
            this.Sidebar.Controls.Add(this.btnFacturacionRedito);
            this.Sidebar.Controls.Add(this.btnFacturacionContado);
            this.Sidebar.Controls.Add(this.btnDashboard);
            this.Sidebar.Controls.Add(this.label2);
            this.Sidebar.Controls.Add(this.pictureBox2);
            this.Sidebar.Controls.Add(this.label3);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.Location = new System.Drawing.Point(0, 0);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Size = new System.Drawing.Size(270, 940);
            this.Sidebar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(47, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Menu Facturación";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(47, 737);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Menu Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(47, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Menu System";
            // 
            // btnLogout
            // 
            this.btnLogout.Activecolor = System.Drawing.Color.Transparent;
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.BorderRadius = 7;
            this.btnLogout.ButtonText = "     Log out";
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogout.ForeColor = System.Drawing.Color.Gray;
            this.btnLogout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogout.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLogout.Iconimage")));
            this.btnLogout.Iconimage_right = null;
            this.btnLogout.Iconimage_right_Selected = null;
            this.btnLogout.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnLogout.Iconimage_Selected")));
            this.btnLogout.IconMarginLeft = 25;
            this.btnLogout.IconMarginRight = 0;
            this.btnLogout.IconRightVisible = true;
            this.btnLogout.IconRightZoom = 0D;
            this.btnLogout.IconVisible = true;
            this.btnLogout.IconZoom = 55D;
            this.btnLogout.IsTab = true;
            this.btnLogout.Location = new System.Drawing.Point(23, 873);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Normalcolor = System.Drawing.Color.Transparent;
            this.btnLogout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnLogout.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnLogout.selected = false;
            this.btnLogout.Size = new System.Drawing.Size(220, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "     Log out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Textcolor = System.Drawing.Color.DarkGray;
            this.btnLogout.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Activecolor = System.Drawing.Color.Transparent;
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClientes.BorderRadius = 7;
            this.btnClientes.ButtonText = "     Clientes";
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.DisabledColor = System.Drawing.Color.Gray;
            this.btnClientes.ForeColor = System.Drawing.Color.Gray;
            this.btnClientes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClientes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnClientes.Iconimage")));
            this.btnClientes.Iconimage_right = null;
            this.btnClientes.Iconimage_right_Selected = null;
            this.btnClientes.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnClientes.Iconimage_Selected")));
            this.btnClientes.IconMarginLeft = 25;
            this.btnClientes.IconMarginRight = 0;
            this.btnClientes.IconRightVisible = true;
            this.btnClientes.IconRightZoom = 0D;
            this.btnClientes.IconVisible = true;
            this.btnClientes.IconZoom = 55D;
            this.btnClientes.IsTab = true;
            this.btnClientes.Location = new System.Drawing.Point(23, 543);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Normalcolor = System.Drawing.Color.Transparent;
            this.btnClientes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnClientes.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnClientes.selected = false;
            this.btnClientes.Size = new System.Drawing.Size(220, 40);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "     Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Textcolor = System.Drawing.Color.DarkGray;
            this.btnClientes.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Activecolor = System.Drawing.Color.Transparent;
            this.btnCompras.BackColor = System.Drawing.Color.Transparent;
            this.btnCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompras.BorderRadius = 7;
            this.btnCompras.ButtonText = "     Compras";
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.DisabledColor = System.Drawing.Color.Gray;
            this.btnCompras.ForeColor = System.Drawing.Color.Gray;
            this.btnCompras.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCompras.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCompras.Iconimage")));
            this.btnCompras.Iconimage_right = null;
            this.btnCompras.Iconimage_right_Selected = null;
            this.btnCompras.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnCompras.Iconimage_Selected")));
            this.btnCompras.IconMarginLeft = 25;
            this.btnCompras.IconMarginRight = 0;
            this.btnCompras.IconRightVisible = true;
            this.btnCompras.IconRightZoom = 0D;
            this.btnCompras.IconVisible = true;
            this.btnCompras.IconZoom = 55D;
            this.btnCompras.IsTab = true;
            this.btnCompras.Location = new System.Drawing.Point(23, 497);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Normalcolor = System.Drawing.Color.Transparent;
            this.btnCompras.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnCompras.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnCompras.selected = false;
            this.btnCompras.Size = new System.Drawing.Size(220, 40);
            this.btnCompras.TabIndex = 0;
            this.btnCompras.Text = "     Compras";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.Textcolor = System.Drawing.Color.DarkGray;
            this.btnCompras.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Activecolor = System.Drawing.Color.Transparent;
            this.btnVentas.BackColor = System.Drawing.Color.Transparent;
            this.btnVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVentas.BorderRadius = 7;
            this.btnVentas.ButtonText = "     Ventas";
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.DisabledColor = System.Drawing.Color.Gray;
            this.btnVentas.ForeColor = System.Drawing.Color.Gray;
            this.btnVentas.Iconcolor = System.Drawing.Color.Transparent;
            this.btnVentas.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnVentas.Iconimage")));
            this.btnVentas.Iconimage_right = null;
            this.btnVentas.Iconimage_right_Selected = null;
            this.btnVentas.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnVentas.Iconimage_Selected")));
            this.btnVentas.IconMarginLeft = 25;
            this.btnVentas.IconMarginRight = 0;
            this.btnVentas.IconRightVisible = true;
            this.btnVentas.IconRightZoom = 0D;
            this.btnVentas.IconVisible = true;
            this.btnVentas.IconZoom = 55D;
            this.btnVentas.IsTab = true;
            this.btnVentas.Location = new System.Drawing.Point(23, 451);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Normalcolor = System.Drawing.Color.Transparent;
            this.btnVentas.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnVentas.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnVentas.selected = false;
            this.btnVentas.Size = new System.Drawing.Size(220, 40);
            this.btnVentas.TabIndex = 0;
            this.btnVentas.Text = "     Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Textcolor = System.Drawing.Color.DarkGray;
            this.btnVentas.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Activecolor = System.Drawing.Color.Transparent;
            this.btnUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsuarios.BorderRadius = 7;
            this.btnUsuarios.ButtonText = "     Usuarios";
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.DisabledColor = System.Drawing.Color.Gray;
            this.btnUsuarios.ForeColor = System.Drawing.Color.Gray;
            this.btnUsuarios.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUsuarios.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Iconimage")));
            this.btnUsuarios.Iconimage_right = null;
            this.btnUsuarios.Iconimage_right_Selected = null;
            this.btnUsuarios.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Iconimage_Selected")));
            this.btnUsuarios.IconMarginLeft = 25;
            this.btnUsuarios.IconMarginRight = 0;
            this.btnUsuarios.IconRightVisible = true;
            this.btnUsuarios.IconRightZoom = 0D;
            this.btnUsuarios.IconVisible = true;
            this.btnUsuarios.IconZoom = 55D;
            this.btnUsuarios.IsTab = true;
            this.btnUsuarios.Location = new System.Drawing.Point(23, 773);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Normalcolor = System.Drawing.Color.Transparent;
            this.btnUsuarios.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnUsuarios.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnUsuarios.selected = false;
            this.btnUsuarios.Size = new System.Drawing.Size(220, 40);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "     Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Textcolor = System.Drawing.Color.DarkGray;
            this.btnUsuarios.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Activecolor = System.Drawing.Color.Transparent;
            this.btnPagar.BackColor = System.Drawing.Color.Transparent;
            this.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPagar.BorderRadius = 7;
            this.btnPagar.ButtonText = "     Pagos";
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.DisabledColor = System.Drawing.Color.Gray;
            this.btnPagar.ForeColor = System.Drawing.Color.Gray;
            this.btnPagar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPagar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnPagar.Iconimage")));
            this.btnPagar.Iconimage_right = null;
            this.btnPagar.Iconimage_right_Selected = null;
            this.btnPagar.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnPagar.Iconimage_Selected")));
            this.btnPagar.IconMarginLeft = 25;
            this.btnPagar.IconMarginRight = 0;
            this.btnPagar.IconRightVisible = true;
            this.btnPagar.IconRightZoom = 0D;
            this.btnPagar.IconVisible = true;
            this.btnPagar.IconZoom = 55D;
            this.btnPagar.IsTab = true;
            this.btnPagar.Location = new System.Drawing.Point(23, 359);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Normalcolor = System.Drawing.Color.Transparent;
            this.btnPagar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnPagar.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnPagar.selected = false;
            this.btnPagar.Size = new System.Drawing.Size(220, 40);
            this.btnPagar.TabIndex = 0;
            this.btnPagar.Text = "     Pagos";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Textcolor = System.Drawing.Color.DarkGray;
            this.btnPagar.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Activecolor = System.Drawing.Color.Transparent;
            this.btnProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProductos.BorderRadius = 7;
            this.btnProductos.ButtonText = "     Productos";
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.DisabledColor = System.Drawing.Color.Gray;
            this.btnProductos.ForeColor = System.Drawing.Color.Gray;
            this.btnProductos.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProductos.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProductos.Iconimage")));
            this.btnProductos.Iconimage_right = null;
            this.btnProductos.Iconimage_right_Selected = null;
            this.btnProductos.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnProductos.Iconimage_Selected")));
            this.btnProductos.IconMarginLeft = 25;
            this.btnProductos.IconMarginRight = 0;
            this.btnProductos.IconRightVisible = true;
            this.btnProductos.IconRightZoom = 0D;
            this.btnProductos.IconVisible = true;
            this.btnProductos.IconZoom = 55D;
            this.btnProductos.IsTab = true;
            this.btnProductos.Location = new System.Drawing.Point(23, 405);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Normalcolor = System.Drawing.Color.Transparent;
            this.btnProductos.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnProductos.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnProductos.selected = false;
            this.btnProductos.Size = new System.Drawing.Size(220, 40);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "     Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Textcolor = System.Drawing.Color.DarkGray;
            this.btnProductos.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnFacturacionRedito
            // 
            this.btnFacturacionRedito.Activecolor = System.Drawing.Color.Transparent;
            this.btnFacturacionRedito.BackColor = System.Drawing.Color.Transparent;
            this.btnFacturacionRedito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFacturacionRedito.BorderRadius = 7;
            this.btnFacturacionRedito.ButtonText = "     A Rédito";
            this.btnFacturacionRedito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionRedito.DisabledColor = System.Drawing.Color.Gray;
            this.btnFacturacionRedito.ForeColor = System.Drawing.Color.Gray;
            this.btnFacturacionRedito.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFacturacionRedito.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFacturacionRedito.Iconimage")));
            this.btnFacturacionRedito.Iconimage_right = null;
            this.btnFacturacionRedito.Iconimage_right_Selected = null;
            this.btnFacturacionRedito.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnFacturacionRedito.Iconimage_Selected")));
            this.btnFacturacionRedito.IconMarginLeft = 25;
            this.btnFacturacionRedito.IconMarginRight = 0;
            this.btnFacturacionRedito.IconRightVisible = true;
            this.btnFacturacionRedito.IconRightZoom = 0D;
            this.btnFacturacionRedito.IconVisible = true;
            this.btnFacturacionRedito.IconZoom = 55D;
            this.btnFacturacionRedito.IsTab = true;
            this.btnFacturacionRedito.Location = new System.Drawing.Point(23, 222);
            this.btnFacturacionRedito.Name = "btnFacturacionRedito";
            this.btnFacturacionRedito.Normalcolor = System.Drawing.Color.Transparent;
            this.btnFacturacionRedito.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnFacturacionRedito.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnFacturacionRedito.selected = false;
            this.btnFacturacionRedito.Size = new System.Drawing.Size(220, 40);
            this.btnFacturacionRedito.TabIndex = 0;
            this.btnFacturacionRedito.Text = "     A Rédito";
            this.btnFacturacionRedito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacionRedito.Textcolor = System.Drawing.Color.DarkGray;
            this.btnFacturacionRedito.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacionRedito.Click += new System.EventHandler(this.btnFacturacionRedito_Click);
            // 
            // btnFacturacionContado
            // 
            this.btnFacturacionContado.Activecolor = System.Drawing.Color.Transparent;
            this.btnFacturacionContado.BackColor = System.Drawing.Color.Transparent;
            this.btnFacturacionContado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFacturacionContado.BorderRadius = 7;
            this.btnFacturacionContado.ButtonText = "     Al Contado";
            this.btnFacturacionContado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionContado.DisabledColor = System.Drawing.Color.Gray;
            this.btnFacturacionContado.ForeColor = System.Drawing.Color.Gray;
            this.btnFacturacionContado.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFacturacionContado.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFacturacionContado.Iconimage")));
            this.btnFacturacionContado.Iconimage_right = null;
            this.btnFacturacionContado.Iconimage_right_Selected = null;
            this.btnFacturacionContado.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnFacturacionContado.Iconimage_Selected")));
            this.btnFacturacionContado.IconMarginLeft = 25;
            this.btnFacturacionContado.IconMarginRight = 0;
            this.btnFacturacionContado.IconRightVisible = true;
            this.btnFacturacionContado.IconRightZoom = 0D;
            this.btnFacturacionContado.IconVisible = true;
            this.btnFacturacionContado.IconZoom = 55D;
            this.btnFacturacionContado.IsTab = true;
            this.btnFacturacionContado.Location = new System.Drawing.Point(23, 268);
            this.btnFacturacionContado.Name = "btnFacturacionContado";
            this.btnFacturacionContado.Normalcolor = System.Drawing.Color.Transparent;
            this.btnFacturacionContado.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnFacturacionContado.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnFacturacionContado.selected = false;
            this.btnFacturacionContado.Size = new System.Drawing.Size(220, 40);
            this.btnFacturacionContado.TabIndex = 0;
            this.btnFacturacionContado.Text = "     Al Contado";
            this.btnFacturacionContado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacionContado.Textcolor = System.Drawing.Color.DarkGray;
            this.btnFacturacionContado.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacionContado.Click += new System.EventHandler(this.btnFacturacionContado_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Activecolor = System.Drawing.Color.Transparent;
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard.BorderRadius = 7;
            this.btnDashboard.ButtonText = "     Dashboard";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btnDashboard.ForeColor = System.Drawing.Color.Gray;
            this.btnDashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Iconimage")));
            this.btnDashboard.Iconimage_right = null;
            this.btnDashboard.Iconimage_right_Selected = null;
            this.btnDashboard.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Iconimage_Selected")));
            this.btnDashboard.IconMarginLeft = 25;
            this.btnDashboard.IconMarginRight = 0;
            this.btnDashboard.IconRightVisible = true;
            this.btnDashboard.IconRightZoom = 0D;
            this.btnDashboard.IconVisible = true;
            this.btnDashboard.IconZoom = 55D;
            this.btnDashboard.IsTab = true;
            this.btnDashboard.Location = new System.Drawing.Point(23, 133);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btnDashboard.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.selected = false;
            this.btnDashboard.Size = new System.Drawing.Size(220, 40);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "     Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Textcolor = System.Drawing.Color.DarkGray;
            this.btnDashboard.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(73, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "MARANATHA";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(17, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(81, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "ELECTRO MUEBLE";
            // 
            // Navbar
            // 
            this.Navbar.BackColor = System.Drawing.Color.White;
            this.Navbar.Controls.Add(this.lblIdentificador);
            this.Navbar.Controls.Add(this.Salir);
            this.Navbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Navbar.Location = new System.Drawing.Point(270, 0);
            this.Navbar.Name = "Navbar";
            this.Navbar.Size = new System.Drawing.Size(1170, 70);
            this.Navbar.TabIndex = 1;
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.lblIdentificador.Location = new System.Drawing.Point(30, 25);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(0, 21);
            this.lblIdentificador.TabIndex = 1;
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Salir.Image = ((System.Drawing.Image)(resources.GetObject("Salir.Image")));
            this.Salir.Location = new System.Drawing.Point(1120, 18);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(35, 35);
            this.Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Salir.TabIndex = 0;
            this.Salir.TabStop = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Wrapper
            // 
            this.Wrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(270, 70);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.Size = new System.Drawing.Size(1170, 870);
            this.Wrapper.TabIndex = 2;
            // 
            // bntPagoF
            // 
            this.bntPagoF.Activecolor = System.Drawing.Color.Transparent;
            this.bntPagoF.BackColor = System.Drawing.Color.Transparent;
            this.bntPagoF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bntPagoF.BorderRadius = 7;
            this.bntPagoF.ButtonText = "     Pagos Facturas";
            this.bntPagoF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntPagoF.DisabledColor = System.Drawing.Color.Gray;
            this.bntPagoF.ForeColor = System.Drawing.Color.Gray;
            this.bntPagoF.Iconcolor = System.Drawing.Color.Transparent;
            this.bntPagoF.Iconimage = ((System.Drawing.Image)(resources.GetObject("bntPagoF.Iconimage")));
            this.bntPagoF.Iconimage_right = null;
            this.bntPagoF.Iconimage_right_Selected = null;
            this.bntPagoF.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("bntPagoF.Iconimage_Selected")));
            this.bntPagoF.IconMarginLeft = 25;
            this.bntPagoF.IconMarginRight = 0;
            this.bntPagoF.IconRightVisible = true;
            this.bntPagoF.IconRightZoom = 0D;
            this.bntPagoF.IconVisible = true;
            this.bntPagoF.IconZoom = 55D;
            this.bntPagoF.IsTab = true;
            this.bntPagoF.Location = new System.Drawing.Point(23, 589);
            this.bntPagoF.Name = "bntPagoF";
            this.bntPagoF.Normalcolor = System.Drawing.Color.Transparent;
            this.bntPagoF.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.bntPagoF.OnHoverTextColor = System.Drawing.Color.DarkGray;
            this.bntPagoF.selected = false;
            this.bntPagoF.Size = new System.Drawing.Size(220, 40);
            this.bntPagoF.TabIndex = 3;
            this.bntPagoF.Text = "     Pagos Facturas";
            this.bntPagoF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntPagoF.Textcolor = System.Drawing.Color.DarkGray;
            this.bntPagoF.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntPagoF.Click += new System.EventHandler(this.bntPagoF_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 940);
            this.Controls.Add(this.Wrapper);
            this.Controls.Add(this.Navbar);
            this.Controls.Add(this.Sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Sidebar.ResumeLayout(false);
            this.Sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Navbar.ResumeLayout(false);
            this.Navbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Sidebar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel Navbar;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.PictureBox Salir;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        private Bunifu.Framework.UI.BunifuFlatButton btnFacturacionContado;
        private Bunifu.Framework.UI.BunifuFlatButton btnVentas;
        private Bunifu.Framework.UI.BunifuFlatButton btnProductos;
        private Bunifu.Framework.UI.BunifuFlatButton btnClientes;
        private Bunifu.Framework.UI.BunifuFlatButton btnCompras;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogout;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnPagar;
        private Bunifu.Framework.UI.BunifuFlatButton btnFacturacionRedito;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuFlatButton btnUsuarios;
        private Bunifu.Framework.UI.BunifuFlatButton bntPagoF;
    }
}