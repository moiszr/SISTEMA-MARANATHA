using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Collections.Generic;


namespace Presentacion
{
    public partial class FrmCompraDetalle : Form
    {
        public FrmCompraDetalle()
        {
            InitializeComponent();
        }

        public void MostarTabla(int id)
        {
            N_Detalle_Compras detalle = new N_Detalle_Compras();
            List<E_Detalle_Compras> ListDetalle = new List<E_Detalle_Compras>();

            ListDetalle = detalle.ListarDetalle_Compras(id);
            TablaCompraDetalle.DataSource = ListDetalle;
            CalculoLabels(ListDetalle);
        }
        public void OcultarMoverAncharColumnas()
        {
            TablaCompraDetalle.Columns[0].Visible = false;
            TablaCompraDetalle.Columns[6].Visible = false;
            TablaCompraDetalle.Columns[7].Visible = false;
            TablaCompraDetalle.Columns[9].Visible = false;
            TablaCompraDetalle.Columns[10].Visible = false;

            TablaCompraDetalle.Columns[1].DisplayIndex = 0;
            TablaCompraDetalle.Columns[11].DisplayIndex = 1;
            TablaCompraDetalle.Columns[8].DisplayIndex = 2;

            TablaCompraDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompraDetalle.Columns[1].Width = 138;
            TablaCompraDetalle.Columns[1].ReadOnly = true;

            TablaCompraDetalle.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompraDetalle.Columns[11].Width = 168;
            TablaCompraDetalle.Columns[11].ReadOnly = true;

            TablaCompraDetalle.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompraDetalle.Columns[8].Width = 224;
            TablaCompraDetalle.Columns[8].ReadOnly = true;

            TablaCompraDetalle.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompraDetalle.Columns[2].Width = 170;
            TablaCompraDetalle.Columns[2].ReadOnly = true;

            TablaCompraDetalle.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaCompraDetalle.Columns[3].Width = 140;
            TablaCompraDetalle.Columns[3].ReadOnly = true;
        }

        private void CalculoLabels(List<E_Detalle_Compras> lista)
        {
            decimal subtotal = 0,  total = 0;

            foreach (var item in lista)
            {
                subtotal += item.Subtotal;
            }
            total = subtotal;

            lblSubtotal.Text = subtotal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblTotal.Text = total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
        }


        private void TablaVentaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
