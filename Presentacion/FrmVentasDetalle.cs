using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Collections.Generic;

namespace Presentacion
{
    public partial class FrmVentasDetalle : Form
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

        public FrmVentasDetalle()
        {
            InitializeComponent();
        }

        public void MostarTabla(int id)
        {
            N_Detalle_Ventas detalle = new N_Detalle_Ventas();
            List<E_Detalle_Ventas> ListDetalle = new List<E_Detalle_Ventas>();

            ListDetalle = detalle.ListarDetalle_Ventas(id);
            TablaVentaDetalle.DataSource = ListDetalle;
            CalculoLabels(ListDetalle);
        }

        public void OcultarMoverAncharColumnas()
        {
            TablaVentaDetalle.Columns[0].Visible = false;
            TablaVentaDetalle.Columns[6].Visible = false;
            TablaVentaDetalle.Columns[7].Visible = false;
            TablaVentaDetalle.Columns[9].Visible = false;
            TablaVentaDetalle.Columns[10].Visible = false;

            TablaVentaDetalle.Columns[1].DisplayIndex = 0;
            TablaVentaDetalle.Columns[11].DisplayIndex = 1;
            TablaVentaDetalle.Columns[8].DisplayIndex = 2;

            TablaVentaDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentaDetalle.Columns[1].Width = 138;
            TablaVentaDetalle.Columns[1].ReadOnly = true;

            TablaVentaDetalle.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentaDetalle.Columns[11].Width = 168;
            TablaVentaDetalle.Columns[11].ReadOnly = true;

            TablaVentaDetalle.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentaDetalle.Columns[8].Width = 224;
            TablaVentaDetalle.Columns[8].ReadOnly = true;

            TablaVentaDetalle.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentaDetalle.Columns[2].Width = 170;
            TablaVentaDetalle.Columns[2].ReadOnly = true;

            TablaVentaDetalle.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentaDetalle.Columns[3].Width = 140;
            TablaVentaDetalle.Columns[3].ReadOnly = true;
        }

        private void CalculoLabels(List<E_Detalle_Ventas> lista)
        {
            decimal subtotal = 0, itbis = 0, descuento = 0, total = 0;

            foreach (var item in lista)
            {
                subtotal += item.Subtotal;
                descuento += (item.Descuento * item.Cantidad);
            }
            total = subtotal + itbis - descuento;

            lblSubtotal.Text = subtotal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblDescuento.Text = descuento.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblTotal.Text = total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TablaVentaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
