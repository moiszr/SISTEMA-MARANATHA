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
using Presentacion.Data;


namespace Presentacion
{
    public partial class FrmMantenimientoPagoFactura : Form
    {
        N_PagosFactura negocio = new N_PagosFactura();
        E_PagosFactura entidades = new E_PagosFactura();

        public FrmMantenimientoPagoFactura()
        {
            InitializeComponent();
            ListarCliente();
        }
        public void ListarCliente()
        {
            N_Cliente ncliente = new N_Cliente();
            cmbClientes.DataSource = ncliente.ListarClienteCB();
            cmbClientes.ValueMember = "IdCliente";
            cmbClientes.DisplayMember = "Nombre";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                entidades.Idcliente = Convert.ToInt32(cmbClientes.SelectedValue);

                entidades.Fecha = DateTime.Now;
                entidades.Descripcion = txtDescripcion.Text;
                entidades.CuotasPagadas = Convert.ToInt32(txtCuotasP.Text);
                entidades.CuotasFaltante = Convert.ToInt32(txtCuotasF.Text);
                entidades.Total = Convert.ToDecimal(txtTotal.Text);
                entidades.IdUsuario = DataUser.idusuario;

                negocio.InsertarPagosFactura(entidades);

                FrmSuccess.ConfirmacionForm("PAGO GUARDADO");

                FrmPagosFactura frm = new FrmPagosFactura();
                Close();
                frm.MostrarTablaPagoFactura();
                Factura.PagoFactura(entidades);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el pago" + ex);
            }
        }
    }
}
