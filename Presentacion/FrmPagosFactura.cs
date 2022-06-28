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
    public partial class FrmPagosFactura : Form
    {

        N_PagosFactura negocio = new N_PagosFactura();
        E_PagosFactura entidad = new E_PagosFactura();

        public FrmPagosFactura()
        {
            InitializeComponent();
            MostrarTablaPagoFactura();
        }
        public void MostrarTablaPagoFactura()
        {
            TablaPago.DataSource = negocio.ListaPagosFactura("");
   
        }
        public void BuscarPagofactura(string buscar)
        {
            TablaPago.DataSource = negocio.ListaPagosFactura(buscar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BuscarPagofactura(txtSearch.Text);
        }
        private void TablaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaPago.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                FrmMantenimientoPagoFactura frm = new FrmMantenimientoPagoFactura();
                frm.cmbClientes.Text = TablaPago.Rows[e.RowIndex].Cells["IDCLIENTE"].Value.ToString();
                frm.txtCodigo.Text = TablaPago.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                frm.txtDescripcion.Text = TablaPago.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
                frm.txtCuotasF.Text = TablaPago.Rows[e.RowIndex].Cells["CUOTASFALTANTE"].Value.ToString();
                frm.txtCuotasP.Text = TablaPago.Rows[e.RowIndex].Cells["CUOTASPAGADAS"].Value.ToString();
                frm.txtTotal.Text = TablaPago.Rows[e.RowIndex].Cells["TOTAL"].Value.ToString();

                frm.ShowDialog();

                MostrarTablaPagoFactura();

            }
        }

        private void btnNewPago_Click(object sender, EventArgs e)
        {
            FrmMantenimientoPagoFactura frm = new FrmMantenimientoPagoFactura();

            frm.ShowDialog();
        }
    }
}
