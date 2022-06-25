using System;
using System.Collections.Generic;
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
    public partial class FrmFacturacionRedito : Form
    {

        decimal Subtotal = 0;
        decimal Total;
        decimal Descuento;

        public FrmFacturacionRedito()
        {
            InitializeComponent();
            ListarProducto();
            ListarCliente();
        }

        public void ListarProducto()
        {
            //N_Productos nproductos = new N_Productos();
            //cmbProductos.DataSource = nproductos.ListarProductos();
            //cmbProductos.ValueMember = "IdProductos";
            //cmbProductos.DisplayMember = "Producto";
        }
        public void ListarCliente()
        {
            //N_Cliente ncliente = new N_Cliente();
            //cmbClientes.DataSource = ncliente.ListarClienteCB();
            //cmbClientes.ValueMember = "IdCliente";
            //cmbClientes.DisplayMember = "Nombre";
        }
        public void imprimir()
        {

           
        //    SaveFileDialog guardar = new SaveFileDialog();
        //    guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

        //    string paginahtml_text = Properties.Resources.plantilla_factura.ToString();
        //    paginahtml_text = paginahtml_text.Replace("@CLIENTE", cmbProductos.SelectedValue.ToString());
        //    paginahtml_text = paginahtml_text.Replace("@USUARIO", DataUser.idusuario.ToString());
        //    paginahtml_text = paginahtml_text.Replace("@FECHA", DateTime.Now.ToString());
        //    paginahtml_text = paginahtml_text.Replace("@TOTAL", lblSubtotal.Text);
        //    paginahtml_text = paginahtml_text.Replace("@TIPO", "CREDITO");


        //    string filas = string.Empty;

        //    foreach (E_Detalle_Compras DCompras in DataUser.eclientes)
        //    {

        //        filas += "<tr>";
        //        filas += "<td>" + DCompras.Producto + "</td>";
        //        filas += "<td>" + DCompras.Preciocompra + "</td>";
        //        filas += "<td>" + DCompras.Cantidad + "</td>";
        //        filas += "<td>" + DCompras.Subtotal + "</td>";
        //        filas += "</tr>";
        //    }
        //    paginahtml_text = paginahtml_text.Replace("@FILAS", filas);


        //    if (guardar.ShowDialog() == DialogResult.OK)
        //    {
        //        using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
        //        {
        //            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

        //            pdfDoc.Open();

        //            pdfDoc.Add(new Phrase(""));

        //            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoTop_1, System.Drawing.Imaging.ImageFormat.Png);
        //            img.ScaleToFit(150, 90);
        //            img.Alignment = iTextSharp.text.Image.UNDERLYING;
        //            img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 70);
        //            pdfDoc.Add(img);

        //            using (StringReader sr = new StringReader(paginahtml_text))
        //            {
        //                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //            }
        //            pdfDoc.Close();

        //            stream.Close();
        //        }
        //    }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
        //    int Idproducto = Convert.ToInt32(cmbProductos.SelectedValue);
        //    List<E_Productos> entidades = new List<E_Productos>();
        //    N_Ventas nproductos = new N_Ventas();
        //    entidades = nproductos.Datafactura(Idproducto);
        //    string Producto = entidades[0].Producto;
        //    decimal PrecioVenta = entidades[0].PrecioVenta;
        //    int Cantidad = Convert.ToInt32(txtCantidad.Text);
        //    decimal SubtotalP = Cantidad * PrecioVenta;

        //    if (Cantidad <= entidades[0].Stock)
        //    {
        //        DataUser.eclientes.Add(new E_Detalle_Compras
        //        {
        //            Preciocompra = PrecioVenta,
        //            Cantidad = Cantidad,
        //            Subtotal = SubtotalP,
        //            Idproducto = Idproducto,
        //            Producto = Producto,

        //        });

        //        txtCantidad.Text = "";
        //        TablaFactCredito.DataSource = DataUser.eclientes;
        //        Subtotal += SubtotalP;
        //        Total = Subtotal - Descuento;
        //        txtTotal.Text = Total.ToString();
        //        lblSubtotal.Text = Subtotal.ToString();
        //    }
        //    else
        //    {
        //        FrmSuccess.ConfirmacionForm("No hay suficiente en stock");
        //        txtCantidad.Text = "";
        //    }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //E_Ventas eventa = new E_Ventas();
            //N_Ventas nventa = new N_Ventas();

            //eventa.Fecha = DateTime.Now;
            //eventa.Total = Convert.ToDecimal(txtTotal.Text);
            //eventa.Nombre_cliente = cmbClientes.SelectedText;
            //eventa.Idusuario = DataUser.idusuario;

            //nventa.InsertarVentas(eventa, DataUser.eproductos);


            ////decimal devuelta = Convert.ToDecimal(txtPagoEnEfectivo.Text) - Convert.ToDecimal(txtTotal.Text);

            

            //FrmSuccess.ConfirmacionForm("PROCESO COMPLETO");
            //imprimir();
        }
    }
}
