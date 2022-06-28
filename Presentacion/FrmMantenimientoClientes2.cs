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
    public partial class FrmMantenimientoClientes2 : Form
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

        FrmClientes frm = new FrmClientes();
        FrmMantenimientoClientes1 frmC1 = new FrmMantenimientoClientes1();
        E_Cliente entidades = new E_Cliente();
        N_Cliente negocio = new N_Cliente();

        public bool Update;


        //Variables data
        public int Idcliente;
        public string CodigoCliente;
        public string Nombre;
        public string Apellido;
        public string Cedula;
        public string Apodo;
        public string Telefono1;
        public string Telefono2;
        public string Celular;
        public string Direccion;
        public string Casa;
        public string LugarDeTrabajo;
        public string TelefonoTrabajo;
        public string NombreSuperior;
        public string TelefonoSuperior;
        public string TiempoLaborando;
        public decimal SalarioMensual;
        public string NombreConyugue;
        public string TelefonoConyuge;
        public string LugarDeTrabajoDelConyugue;
        public string TrabajoConyugue;
        public string TelefonoTrabajoConyugue;
        public string NombreSuperiorConyugue;
        public string TelefonoSuperiorConyugue;
        public string TiempoLaborandoConyugue;
        public decimal SalarioMensualConyugue;

        public FrmMantenimientoClientes2()
        {
            m_aeroEnabled = false;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {   
            
            
            this.Hide();
            FrmMantenimientoClientes1 frm = new FrmMantenimientoClientes1();

            frm.txtIdCliente.Text = CodigoCliente;
            frm.txtNombreCliente.Text = Nombre;
            frm.txtApellidoCliente.Text = Apellido;
            frm.txtCedula.Text = Cedula;
            frm.txtApodoCliente.Text = Apodo;
            frm.txtTelefonoResidencial.Text = Telefono1;
            frm.txtOtroTelefono.Text = Telefono2;
            frm.txtTelefonoCelularCliente.Text = Celular;
            frm.txtDireccion.Text = Direccion;

            frm.txtLugarDeTrabajo.Text = LugarDeTrabajo;
            frm.txtTelefonoTrabajo.Text = TelefonoTrabajo;
            frm.txtNombredelSuperiorInmediato.Text = NombreSuperior;
            frm.txtTelefonoDelSuperiorInmediato.Text = TelefonoSuperior;
            frm.txtTiempoLaborando.Text = TiempoLaborando;
            frm.txtSalarioMensual.Text = SalarioMensual.ToString();
            frm.txtNombreDelConyugue.Text = NombreConyugue;
            frm.txtTelefonoDelConyugue.Text = TelefonoConyuge;
            frm.txtLugarDeTrabajoDelConyugue.Text = LugarDeTrabajoDelConyugue;
            frm.txtTelefonoDeTrabajoDelConyugue.Text = TelefonoTrabajoConyugue;
            frm.txtNombreDelSuperiorConyugue.Text = NombreSuperiorConyugue;
            frm.txtTelefonoSuperiorConyugue.Text = TelefonoSuperiorConyugue;
            frm.txtTiempoLaborandoConyugue.Text = TiempoLaborandoConyugue;
            frm.txtSalarioMensualConyugue.Text = SalarioMensualConyugue.ToString();


      
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Idcliente < 0)
            {
                try
                {

                    entidades.Nombre = Nombre;
                    entidades.Apellido = Apellido;
                    entidades.Cedula = Cedula;
                    entidades.Apodo = Apodo;
                    entidades.Telefono1 = Telefono1;
                    entidades.Telefono2 = Telefono2;
                    entidades.Celular = Celular;
                    entidades.Direccion = Direccion;
                    entidades.Casa = Casa;
                    entidades.LugarDeTrabajo = LugarDeTrabajo;
                    entidades.TelefonoTrabajo = TelefonoTrabajo;
                    entidades.NombreSuperior = NombreSuperior;
                    entidades.TelefonoSuperior = TelefonoSuperior;
                    entidades.TiempoLaborando = TiempoLaborando;
                    entidades.SalarioMensual = SalarioMensual;
                    entidades.NombreConyugue = NombreConyugue;
                    entidades.TelefonoConyuge = TelefonoConyuge;
                    entidades.TrabajoConyugue = TrabajoConyugue;
                    entidades.TelefonoTrabajoConyugue = TelefonoTrabajoConyugue;
                    entidades.NombreSuperiorConyugue = NombreSuperiorConyugue;
                    entidades.TelefonoSuperiorConyugue = TelefonoSuperiorConyugue;
                    entidades.TiempoLaborandoConyugue = TiempoLaborandoConyugue;
                    entidades.SalarioMensualConyugue = SalarioMensualConyugue;
                    entidades.Nombre_Apellido_Telefono_Referencia1 = txtNombreReferenciaPer1.Text.ToUpper() + "  " + txtApellidosReferenciaPer1.Text.ToUpper() + "  " + txtTelefonoReferenciaPer1.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Referencia2 = txtNombreReferenciaPer2.Text.ToUpper() + "  " + txtApellidosReferenciaPer2.Text.ToUpper() + "  " + txtTelefonoReferenciaPer2.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Referencia3 = txtNombreReferenciaPer3.Text.ToUpper() + "  " + txtApellidosReferenciaPer3.Text.ToUpper() + "  " + txtTelefonoReferenciaPer3.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Familiar1 = txtNombreFamilaresCerc1.Text.ToUpper() + "  " + txtApellidosFamilaresCerc1.Text.ToUpper() + "  " + txtTelefonoFamilaresCerc1.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Familiar2 = txtNombreFamilaresCerc2.Text.ToUpper() + "  " + txtApellidosFamilaresCerc2.Text.ToUpper() + "  " + txtTelefonoFamilaresCerc2.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Familiar3 = txtNombreFamilaresCerc3.Text.ToUpper() + "  " + txtApellidosFamilaresCerc3.Text.ToUpper() + "  " + txtTelefonoFamilaresCerc3.Text.ToUpper();


                    negocio.InsertarCliente(entidades);

                    FrmSuccess.ConfirmacionForm("CLIENTE GUARDADO");

                    Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el cliente" + ex);
                }
            }
            if (Idcliente >= 0)
            {
                try
                {
                    entidades.IdCliente = Idcliente;
                    entidades.Nombre = Nombre;
                    entidades.Apellido = Apellido;
                    entidades.Cedula = Cedula;
                    entidades.Apodo = Apodo;
                    entidades.Telefono1 = Telefono1;
                    entidades.Telefono2 = Telefono2;
                    entidades.Celular = Celular;
                    entidades.Direccion = Direccion;
                    entidades.Casa = Casa;
                    entidades.LugarDeTrabajo = LugarDeTrabajo;
                    entidades.TelefonoTrabajo = TelefonoTrabajo;
                    entidades.NombreSuperior = NombreSuperior;
                    entidades.TelefonoSuperior = TelefonoSuperior;
                    entidades.TiempoLaborando = TiempoLaborando;
                    entidades.SalarioMensual = SalarioMensual;
                    entidades.NombreConyugue = NombreConyugue;
                    entidades.TelefonoConyuge = TelefonoConyuge;
                    entidades.TrabajoConyugue = TrabajoConyugue;
                    entidades.TelefonoTrabajoConyugue = TelefonoTrabajoConyugue;
                    entidades.NombreSuperiorConyugue = NombreSuperiorConyugue;
                    entidades.TelefonoSuperiorConyugue = TelefonoSuperiorConyugue;
                    entidades.TiempoLaborandoConyugue = TiempoLaborandoConyugue;
                    entidades.SalarioMensualConyugue = SalarioMensualConyugue;
                    entidades.Nombre_Apellido_Telefono_Referencia1 = txtNombreReferenciaPer1.Text.ToUpper() + "  " + txtApellidosReferenciaPer1.Text.ToUpper() + "  " + txtTelefonoReferenciaPer1.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Referencia2 = txtNombreReferenciaPer2.Text.ToUpper() + "  " + txtApellidosReferenciaPer2.Text.ToUpper() + "  " + txtTelefonoReferenciaPer2.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Referencia3 = txtNombreReferenciaPer3.Text.ToUpper() + "  " + txtApellidosReferenciaPer3.Text.ToUpper() + "  " + txtTelefonoReferenciaPer3.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Familiar1 = txtNombreFamilaresCerc1.Text.ToUpper() + "  " + txtApellidosFamilaresCerc1.Text.ToUpper() + "  " + txtTelefonoFamilaresCerc1.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Familiar2 = txtNombreFamilaresCerc2.Text.ToUpper() + "  " + txtApellidosFamilaresCerc2.Text.ToUpper() + "  " + txtTelefonoFamilaresCerc2.Text.ToUpper();
                    entidades.Nombre_Apellido_Telefono_Familiar3 = txtNombreFamilaresCerc3.Text.ToUpper() + "  " + txtApellidosFamilaresCerc3.Text.ToUpper() + "  " + txtTelefonoFamilaresCerc3.Text.ToUpper();

                    negocio.EditarCliente(entidades);

                    FrmSuccess.ConfirmacionForm("CLIENTE EDITADO");

                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el cliente" + ex);
                }
            }

        }

        private void txtTelefonoReferenciaPer1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
