using System;
using System.Windows.Forms;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Collections.Generic;
using Negocio;

namespace Presentacion.Data
{
    public class Factura
    {
        public static void Contado(E_Ventas e_Ventas, List<E_Productos> listProductos)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            string paginahtml_text = Properties.Resources.plantilla_factura.ToString();
            paginahtml_text = paginahtml_text.Replace("@CLIENTE", e_Ventas.Nombre_cliente);
            paginahtml_text = paginahtml_text.Replace("@USUARIO", DataUser.nombre.ToString() + " " + DataUser.apellido.ToString());
            paginahtml_text = paginahtml_text.Replace("@FECHA", DateTime.Now.ToString());
            paginahtml_text = paginahtml_text.Replace("@TOTAL", e_Ventas.Total.ToString());
            paginahtml_text = paginahtml_text.Replace("@TIPO", "CONTANDO");

            string filas = string.Empty;

            foreach (E_Detalle_Ventas DVentas in DataVentas.ListDetalle_v)
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
                    img.ScaleToFit(150, 90);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 70);
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


        public static void PagoFactura(E_PagosFactura pagosFactura)
        {
            List<E_Cliente> facturaList = new List<E_Cliente>();
            N_Cliente n_Cliente = new N_Cliente();

            facturaList = n_Cliente.BuscarClienteId(pagosFactura.Idcliente);
            
            string Nombre = facturaList[0].Nombre;


            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            string paginahtml_text = Properties.Resources.Pagofactura.ToString();
            paginahtml_text = paginahtml_text.Replace("@CLIENTE", Nombre);
            paginahtml_text = paginahtml_text.Replace("@USUARIO", DataUser.nombre.ToString() + " " + DataUser.apellido.ToString());
            paginahtml_text = paginahtml_text.Replace("@FECHA", DateTime.Now.ToString());
            paginahtml_text = paginahtml_text.Replace("@TOTAL", pagosFactura.Total.ToString());
            paginahtml_text = paginahtml_text.Replace("@TIPO", "PAGO CREDITO");


            string filas = string.Empty;

                filas += "<tr>";
                filas += "<td>" + pagosFactura.Descripcion + "</td>";
                filas += "<td>" + pagosFactura.CuotasPagadas + "</td>";
                filas += "<td>" + pagosFactura.CuotasFaltante + "</td>";
                filas += "<td>" + pagosFactura.Total + "</td>";
                filas += "</tr>";
            
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
                    img.ScaleToFit(150, 90);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 70);
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
