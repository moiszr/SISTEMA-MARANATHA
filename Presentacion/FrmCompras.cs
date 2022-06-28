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
namespace Presentacion
{
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
            MostarTabla();
            OcultarMoverAncharColumnas();
        }
        public void OcultarMoverAncharColumnas()
        {

            TablaCompra.Columns[1].Visible = false;
            TablaCompra.Columns[8].Visible = false;
            TablaCompra.Columns[2].Visible = false;


            TablaCompra.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompra.Columns[7].Width = 175;

            TablaCompra.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompra.Columns[3].Width = 350;

            TablaCompra.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompra.Columns[4].Width = 350;

            TablaCompra.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompra.Columns[5].Width = 200;
            TablaCompra.Columns[5].ReadOnly = true;

            TablaCompra.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompra.Columns[6].Width = 195;
            TablaCompra.Columns[6].ReadOnly = true;
        }
        

        private void btnFormMarcas_Click(object sender, EventArgs e)
        {
            FrmFacturacionCompra frm = new FrmFacturacionCompra();
            this.Hide();
            frm.ShowDialog();
        }
        public void MostarTabla()
        {
            N_Compras ncompra = new N_Compras();
            TablaCompra.DataSource = ncompra.ListarCompras();
        }


        private void TablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaCompra.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                int id = Convert.ToInt32(TablaCompra.Rows[e.RowIndex].Cells["IDCOMPRA"].Value.ToString());

                FrmCompraDetalle frm = new FrmCompraDetalle();
                frm.MostarTabla(id);
                frm.ShowDialog();
            }

        }
    }
}
