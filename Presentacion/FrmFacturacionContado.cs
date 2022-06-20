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
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Presentacion
{
    public partial class FrmFacturacionContado : Form
    {
        decimal Subtotal = 0;
        decimal Total;
        decimal Descuento;

        public FrmFacturacionContado()
        {
            InitializeComponent();
            ListarProducto();
        }

        public void mostrartabla(List<E_Detalle_Ventas> eproductos)
        {
            TablaFactContado.DataSource = eproductos;

        }
        public void ListarProducto()
        {
            N_Productos nproductos = new N_Productos();
            cmbProducto.DataSource = nproductos.ListarProductos();
            cmbProducto.ValueMember = "IdProductos";
            cmbProducto.DisplayMember = "Producto";
        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int Idproducto = Convert.ToInt32(cmbProducto.SelectedValue);
            List<E_Productos> entidades = new List<E_Productos>();
            N_Ventas nproductos = new N_Ventas();
            entidades = nproductos.Datafactura(Idproducto);
            decimal Preciocompra = entidades[0].PrecioVenta;
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal SubtotalP = Cantidad * Preciocompra;
            

            DataUser.eproductos.Add(new E_Detalle_Ventas
            {
                    Preciocompra = Preciocompra,
                    Cantidad = Cantidad,
                    Subtotal = SubtotalP,
                    Idproducto = Idproducto,
                    
            });
            
            txtCantidad.Text = "";
            TablaFactContado.DataSource = DataUser.eproductos;
            Subtotal += SubtotalP;
            Total = Subtotal - Descuento;
            lblTotal.Text = Total.ToString();
            lblSubtotal.Text = Subtotal.ToString(); 

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            E_Ventas eventa = new E_Ventas();
            N_Ventas nventa = new N_Ventas();

            eventa.Fecha = DateTime.Now;
            eventa.Total = Convert.ToDecimal(lblTotal.Text);
            eventa.Nombre_cliente = txtCliente.Text;
            eventa.Idusuario = DataUser.idusuario;

            nventa.InsertarVentas(eventa, DataUser.eproductos);

            decimal devuelta = Convert.ToDecimal(txtPagoEnEfectivo.Text) - Convert.ToDecimal(lblTotal.Text);

            FrmSuccess.ConfirmacionForm("PROCESO COMPLETO" + devuelta);

        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.ShowDialog();
        }
    }
}
