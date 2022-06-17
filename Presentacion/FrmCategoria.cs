using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmCategoria : Form
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

        private string IDCategoria;
        private bool Editarse = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();

        public FrmCategoria()
        {
            m_aeroEnabled = false;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            MostrarBuscarTabla("");
            AccionesTable();
        }

        public void AccionesTable()
        {
            tblCategoria.Columns[0].Visible = false;
            tblCategoria.Columns[1].Width = 90;
            tblCategoria.Columns[2].Width = 190;

            tblCategoria.ClearSelection();
        }

        public void LimpiarCajas()
        {
            lblCode.Text = "";
            txtPorcientoPrecio.Text = "";
            txtDescription.Text = "";
        }

        public void MostrarBuscarTabla(string buscar)
        {
            tblCategoria.DataSource = objNegocio.ListarCategorias(buscar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MostrarBuscarTabla(txtSearch.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tblCategoria.ClearSelection();
            Editarse = false;
            LimpiarCajas();
            txtPorcientoPrecio.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(tblCategoria.SelectedRows.Count > 0)
            {
                Editarse = true;
                IDCategoria = tblCategoria.CurrentRow.Cells[0].Value.ToString();
                lblCode.Text = tblCategoria.CurrentRow.Cells[1].Value.ToString();
                txtPorcientoPrecio.Text = tblCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescription.Text = tblCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Editarse == false)
            {
                try
                {
                    objEntidad.NombreCategoria = txtPorcientoPrecio.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescription.Text.ToUpper();

                    objNegocio.InsertarCategoria(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarBuscarTabla("");
                    LimpiarCajas();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }

            if(Editarse == true)
            {
                try
                {
                    objEntidad.IdCategoria = Convert.ToInt32(IDCategoria);
                    objEntidad.NombreCategoria = txtPorcientoPrecio.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescription.Text.ToUpper();

                    objNegocio.EditarCategoria(objEntidad);

                    MessageBox.Show("Se edito el registro");
                    MostrarBuscarTabla("");
                    LimpiarCajas();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tblCategoria.SelectedRows.Count > 0)
            {
                objEntidad.IdCategoria = Convert.ToInt32(tblCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminarCategoria(objEntidad);

                MessageBox.Show("Se elimino el registro correctamente");
                MostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea eliminar");
            }    
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            worksheet = workbook.Sheets[1];
            worksheet.Name = "Categorias";

            for (int i = 1; i < tblCategoria.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = tblCategoria.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < tblCategoria.Rows.Count; i++)
            {
                for (int j = 0; j < tblCategoria.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = tblCategoria.Rows[i].Cells[j].Value.ToString();
                }
            }

            app.Visible = true;
        }
    }
}
