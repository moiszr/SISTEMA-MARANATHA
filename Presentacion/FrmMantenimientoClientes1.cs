using System;
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
    public partial class FrmMantenimientoClientes1 : Form
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

        public FrmMantenimientoClientes1()
        {
            m_aeroEnabled = false;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            decimal SalarioMensual = 0;
            decimal SalarioMensualConyugue = 0;

            if (txtSalarioMensual.Text != "")
            {
                SalarioMensual = Convert.ToDecimal(txtSalarioMensual.Text);
            }
            if (txtSalarioMensualConyugue.Text != "")
            {
                SalarioMensualConyugue = Convert.ToDecimal(txtSalarioMensualConyugue.Text);
            }

            FrmMantenimientoClientes2 frm = new FrmMantenimientoClientes2();

            frm.CodigoCliente = txtIdCliente.Text.ToUpper();
            frm.Nombre = txtNombreCliente.Text.ToUpper();
            frm.Apellido = txtApellidoCliente.Text.ToUpper();
            frm.Cedula = txtCedula.Text.ToUpper();
            frm.Apodo = txtApodoCliente.Text.ToUpper();
            frm.Telefono1 = txtTelefonoResidencial.Text.ToUpper();
            frm.Telefono2 = txtOtroTelefono.Text.ToUpper();
            frm.Celular = txtTelefonoCelularCliente.Text.ToUpper();
            frm.Direccion = txtDireccion.Text.ToUpper();
            frm.LugarDeTrabajo = txtLugarDeTrabajo.Text.ToUpper();
            frm.TelefonoTrabajo = txtTelefonoTrabajo.Text.ToUpper();
            frm.NombreSuperior = txtNombredelSuperiorInmediato.Text.ToUpper();
            frm.TelefonoSuperior = txtTelefonoDelSuperiorInmediato.Text.ToUpper();
            frm.TiempoLaborando = txtTiempoLaborando.Text.ToUpper();
            frm.SalarioMensual = SalarioMensual;
            frm.NombreConyugue = txtNombreDelConyugue.Text.ToUpper();
            frm.TelefonoConyuge = txtTelefonoDelConyugue.Text.ToUpper();
            frm.TrabajoConyugue = txtLugarDeTrabajoDelConyugue.Text.ToUpper();
            frm.TelefonoTrabajoConyugue = txtTelefonoDeTrabajoDelConyugue.Text.ToUpper();
            frm.NombreSuperiorConyugue = txtNombreDelSuperiorConyugue.Text.ToUpper();
            frm.TelefonoSuperiorConyugue = txtTelefonoSuperiorConyugue.Text.ToUpper();
            frm.TiempoLaborandoConyugue = txtTiempoLaborandoConyugue.Text.ToUpper();
            frm.SalarioMensualConyugue = SalarioMensualConyugue;

           

            if (rdbPropia.Checked)
            {
                frm.Casa = "Propia".ToUpper();
            }
            if (rdbAlquilada.Checked)
            {
                frm.Casa = "Alquilada".ToUpper();
            }

            this.Hide();
            frm.ShowDialog();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalarioMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSalarioMensualConyugue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}