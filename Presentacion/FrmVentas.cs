using System;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class FrmVentas : Form
    {
        N_Ventas nventas = new N_Ventas();

        public FrmVentas()
        {
            InitializeComponent();
            MostarTabla();
            OcultarMoverAncharColumnas();
        }

        public void OcultarMoverAncharColumnas()
        {
            TablaVentas.Columns[1].Visible = false;
            TablaVentas.Columns[7].Visible = false;
            TablaVentas.Columns[8].Visible = false;

            TablaVentas.Columns["DETALLE"].DisplayIndex = 7;

            TablaVentas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentas.Columns[2].Width = 175;

            TablaVentas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentas.Columns[3].Width = 350;

            TablaVentas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentas.Columns[4].Width = 350;

            TablaVentas.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentas.Columns[5].Width = 200;
            TablaVentas.Columns[5].ReadOnly = true;

            TablaVentas.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaVentas.Columns[6].Width = 195;
            TablaVentas.Columns[6].ReadOnly = true;
        }
        
        public void MostarTabla()
        {
            N_Ventas nventas = new N_Ventas();
            TablaVentas.DataSource = nventas.ListarVentas();
        }

        private void TablaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (TablaVentas.Rows[e.RowIndex].Cells["DETALLE"].Selected)
                {
                    int id = Convert.ToInt32(TablaVentas.Rows[e.RowIndex].Cells["IDVENTA"].Value.ToString());

                    FrmVentasDetalle frm = new FrmVentasDetalle();
                    frm.MostarTabla(id);
                    frm.OcultarMoverAncharColumnas();

                    frm.ShowDialog();
                }
        }
    }
}
