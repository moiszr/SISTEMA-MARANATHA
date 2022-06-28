﻿using System;
using Presentacion.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class FrmMantenimientoProductos : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }

        FrmProductos frm = new FrmProductos();
        E_Productos entidades = new E_Productos();
        N_Productos negocio = new N_Productos();

        public bool Update = false;

        public FrmMantenimientoProductos()
        {
            m_aeroEnabled = false;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            ListarCategorias();
            ListarMarcas();
        }

        public void ListarCategorias()
        {
            N_Categoria nCategoria = new N_Categoria();
            cmbCategorias.DataSource = nCategoria.ListarCategorias("");
            cmbCategorias.ValueMember = "IdCategoria";
            cmbCategorias.DisplayMember = "NombreCategoria";
        }

        public void ListarMarcas()
        {
            N_Marca nCategoria = new N_Marca();
            cmbMarcas.DataSource = nCategoria.ListarMarca("");
            cmbMarcas.ValueMember = "IdMarca";
            cmbMarcas.DisplayMember = "NombreMarca";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Update == false)
            {
                try
                {
                    entidades.Producto = txtNombreProducto.Text.ToUpper();
                    entidades.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidades.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidades.Stock = Convert.ToInt32(txtStock.Text);
                    entidades.Idcategoria = Convert.ToInt32(cmbCategorias.SelectedValue);
                    entidades.Idmarca = Convert.ToInt32(cmbMarcas.SelectedValue);

                    negocio.InsertandoProductos(entidades);

                    FrmSuccess.ConfirmacionForm("PRODUCTO GUARDADO");

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el producto" + ex);
                }
            }
            if (Update == true)
            {
                try
                {
                    entidades.IdProductos = Convert.ToInt32(txtIdProductos.Text);
                    entidades.Producto = txtNombreProducto.Text.ToUpper();
                    entidades.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidades.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidades.Stock = Convert.ToInt32(txtStock.Text);
                    entidades.Idcategoria = Convert.ToInt32(cmbCategorias.SelectedValue);
                    entidades.Idmarca = Convert.ToInt32(cmbMarcas.SelectedValue);

                    negocio.EditandoProdcutos(entidades);

                    FrmSuccess.ConfirmacionForm("PRODUCTO EDITADO");

                    Close();

                    Update = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el producto" + ex);
                }
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
   
            N_Categoria categoria = new N_Categoria();
            int id = Convert.ToInt32(cmbCategorias.SelectedValue);
            DataProduct.ListCategoria = categoria.BuscarCategoriasXID(id);

            int PrecioCompra = Convert.ToInt32(txtPrecioCompra.Text);
            txtPrecioVenta.Text = (PrecioCompra * ((DataProduct.ListCategoria[0].Porciento_Venta / 100)+1)).ToString();
        }
    }
}
