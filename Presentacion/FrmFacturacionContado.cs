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
using iTextSharp.tool.xml;
using System.IO;

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
            string Producto = entidades[0].Producto;
            decimal PrecioVenta = entidades[0].PrecioVenta;
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal SubtotalP = Cantidad * PrecioVenta;
            

            DataUser.eproductos.Add(new E_Detalle_Ventas
            {
                    Preciocompra = PrecioVenta,
                    Cantidad = Cantidad,
                    Subtotal = SubtotalP,
                    Idproducto = Idproducto,
                    Producto = Producto,

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
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            string paginahtml_text = Properties.Resources.plantilla_factura.ToString();
            paginahtml_text = paginahtml_text.Replace("@CLIENTE", txtCliente.Text);
            paginahtml_text = paginahtml_text.Replace("@USUARIO", DataUser.idusuario.ToString());
            paginahtml_text = paginahtml_text.Replace("@FECHA", DateTime.Now.ToString());
            paginahtml_text = paginahtml_text.Replace("@TOTAL", lblSubtotal.Text);

            string filas = string.Empty;

            foreach (E_Detalle_Ventas DVentas in DataUser.eproductos)
            {
              
                filas += "<tr>";
                filas += "<td>" + DVentas.Producto + "</td>";
                filas += "<td>" + DVentas.Preciocompra + "</td>";
                filas += "<td>" + DVentas.Cantidad + "</td>";
                filas += "<td>" + DVentas.Subtotal + "</td>";
                filas += "</tr>";
            }
            paginahtml_text = paginahtml_text.Replace("@FILAS", filas);


            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoTop_1, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(120, 90);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 30);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(paginahtml_text))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();

                    stream.Close();
                }

            }
        }
    }
}
