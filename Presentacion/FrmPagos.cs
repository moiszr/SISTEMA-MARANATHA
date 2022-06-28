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

namespace Presentacion
{
    public partial class FrmPagos : Form
    {
        public FrmPagos()
        {
            InitializeComponent();
            MostarTabla();
            OcultarMoverAncharColumnas();
        }

        public void OcultarMoverAncharColumnas()
        {
            TablaPagos.Columns[2].Visible = false;
            TablaPagos.Columns[9].Visible = false;
            TablaPagos.Columns[10].Visible = false;
            TablaPagos.Columns[11].Visible = false;

            TablaPagos.Columns[0].DisplayIndex = 10;
            TablaPagos.Columns[1].DisplayIndex = 10;

            TablaPagos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[3].Width = 160;
            TablaPagos.Columns[3].ReadOnly = true;

            TablaPagos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[4].Width = 160;
            TablaPagos.Columns[4].ReadOnly = true;

            TablaPagos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[5].Width = 160;
            TablaPagos.Columns[5].ReadOnly = true;

            TablaPagos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[6].Width = 200;
            TablaPagos.Columns[6].ReadOnly = true;

            TablaPagos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[7].Width = 270;
            TablaPagos.Columns[7].ReadOnly = true;

            TablaPagos.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[8].Width = 270;
            TablaPagos.Columns[8].ReadOnly = true;

            TablaPagos.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaPagos.Columns[10].Width = 100;
        }

        public void MostarTabla()
        {
            N_Pagos n_Pagos = new N_Pagos();
            TablaPagos.DataSource = n_Pagos.ListarPagos();
        }

        private void TablaPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaPagos.Rows[e.RowIndex].Cells[0].Selected)
            {
                List<E_Garante> ListGarante = new List<E_Garante>();
                int idGarante = Convert.ToInt32(TablaPagos.Rows[e.RowIndex].Cells[11].Value.ToString());
                string codePago = TablaPagos.Rows[e.RowIndex].Cells[3].Value.ToString();
                string codeVenta = TablaPagos.Rows[e.RowIndex].Cells[5].Value.ToString();
                string cedula = TablaPagos.Rows[e.RowIndex].Cells[6].Value.ToString();
                string cliente = TablaPagos.Rows[e.RowIndex].Cells[7].Value.ToString();

                N_Garante n_Garante = new N_Garante();
                ListGarante = n_Garante.ListarGarante(idGarante);

                FrmGarante frm = new FrmGarante();
                foreach(E_Garante Garante in ListGarante)
                {
                    frm.lblCodigoPago.Text = codePago.ToString();
                    frm.lblCodigoVenta.Text = codeVenta.ToString();
                    frm.lblCedulaCli.Text = cedula.ToString();
                    frm.lblCliente.Text = cliente.ToString();
                    
                    frm.lblId.Text = Garante.Idgarante.ToString();
                    frm.lblCodigo.Text = Garante.Codigo.ToString();
                    frm.lblNombre.Text = Garante.Nombre.ToString();
                    frm.lblApellido.Text = Garante.Apellido.ToString();
                    frm.lblCedula.Text = Garante.Cedula.ToString();
                    frm.lblTelefono.Text = Garante.Telefono.ToString();
                    frm.lblCelular.Text = Garante.Celular.ToString();
                    frm.lblDireccion.Text = Garante.Direccion.ToString();
                    frm.lblTrabajo.Text = Garante.Trabajo.ToString();
                    frm.lblSueldo.Text = Garante.Sueldo.ToString();
                }

                frm.ShowDialog();
            } 
            else if (TablaPagos.Rows[e.RowIndex].Cells[1].Selected)
            {
                int idPago = Convert.ToInt32(TablaPagos.Rows[e.RowIndex].Cells[2].Value.ToString());

                FrmCredito frm = new FrmCredito();
                frm.MostarTabla(idPago);
                frm.OcultarMoverAncharColumnas();
                frm.ShowDialog();
            }
        }
    }
}
