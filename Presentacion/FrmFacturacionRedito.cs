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
using Presentacion.Data;

namespace Presentacion
{
    public partial class FrmFacturacionRedito : Form
    {
        N_Ventas n_Ventas = new N_Ventas();
        E_Ventas e_Ventas = new E_Ventas();

        private decimal totalpago;

        public FrmFacturacionRedito()
        {
            InitializeComponent();
            LimpiarListas();
            ListarProducto();
            ListarCliente();

            txtInicialDePago.Enabled = false;
        }

        public void ListarProducto()
        {
            N_Productos nproductos = new N_Productos();
            cmbProductos.DataSource = nproductos.ListarProductos();
            cmbProductos.ValueMember = "IdProductos";
            cmbProductos.DisplayMember = "Producto";
        }
        
        public void ListarCliente()
        {
            N_Cliente ncliente = new N_Cliente();
            cmbClientes.DataSource = ncliente.ListarClienteCB();
            cmbClientes.ValueMember = "IdCliente";
            cmbClientes.DisplayMember = "Nombre";
        }

        private void LimpiarListas()
        {
            DataProduct.ListCategoria.Clear();
            DataProduct.ListProductos.Clear();
            DataVentas.ListDetalle_v.Clear();
            DataCredito.ListGarante.Clear();
            DataCredito.ListCredito.Clear();
        }

        public void OcultarMoverAncharColumnas()
        {
            TablaFactCredito.Columns[3].Visible = false;
            TablaFactCredito.Columns[4].Visible = false;
            TablaFactCredito.Columns[9].Visible = false;
            TablaFactCredito.Columns[10].Visible = false;
            TablaFactCredito.Columns[13].Visible = false;

            TablaFactCredito.Columns[12].DisplayIndex = 0;
            TablaFactCredito.Columns[11].DisplayIndex = 1;
            TablaFactCredito.Columns[5].DisplayIndex = 2;
            TablaFactCredito.Columns[6].DisplayIndex = 3;
            TablaFactCredito.Columns[7].DisplayIndex = 4;
            TablaFactCredito.Columns[8].DisplayIndex = 5;
            TablaFactCredito.Columns[1].DisplayIndex = 6;
            TablaFactCredito.Columns[0].DisplayIndex = 6;
            TablaFactCredito.Columns[2].DisplayIndex = 6;

            TablaFactCredito.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactCredito.Columns[12].Width = 155;

            TablaFactCredito.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactCredito.Columns[11].Width = 275;
            TablaFactCredito.Columns[11].ReadOnly = true;

            TablaFactCredito.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactCredito.Columns[5].Width = 207;
            TablaFactCredito.Columns[5].ReadOnly = true;

            TablaFactCredito.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactCredito.Columns[6].Width = 198;
            TablaFactCredito.Columns[6].ReadOnly = true;

            TablaFactCredito.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactCredito.Columns[7].Width = 210;
            TablaFactCredito.Columns[7].ReadOnly = true;

            TablaFactCredito.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactCredito.Columns[8].Width = 220;
            TablaFactCredito.Columns[8].ReadOnly = true;
        }

        public void MostrarTablaCredito()
        {
            TablaFactCredito.DataSource = null;
            TablaFactCredito.DataSource = DataVentas.ListDetalle_v;
            OcultarMoverAncharColumnas();
        }

        private void CalculoLabels()
        {
            decimal subtotal = 0, descuento = 0, total = 0;

            foreach (var item in DataVentas.ListDetalle_v)
            {
                subtotal += item.Subtotal;
                descuento += (item.Descuento * item.Cantidad);
            }
            total = subtotal - descuento;
            totalpago = total;

            lblSubtotal.Text = subtotal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblDescuento.Text = descuento.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblTotal.Text = total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            try
            {
                lblRestante.Text = PagoWithInteres().ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
                decimal cuotas = PagoWithInteres() / Convert.ToInt16(txtCuotasEnMeses.Text);
                lblcuotas.Text = cuotas.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            }catch{}
            
        }

        private void LimpiarFacturacion()
        {
            //Limpiar los datos del garante
            txtNombreGarante.Text = "";
            txtApellidoGarante.Text = "";
            txtCelularGarante.Text = "";
            txtTelefonoGarante.Text = "";
            txtCedulaGarante.Text = "";
            txtDireccionGarante.Text = "";
            txtTrabajoGarante.Text = "";
            txtSueldoGarante.Text = "";

            //Limpiar datos de factura;
            cmbClientes.ResetText();
            cmbProductos.ResetText();
            txtCantidad.Text = "";
            txtCuotasEnMeses.Text = "";
            txtInicialDePago.Text = "";

            //Limpiar datos del total de los labels
            lblSubtotal.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblTotal.Text = "0.00";
            lblInicial.Text = "0.00";
            lblRestante.Text = "0.00";

            DataVentas.ListDetalle_v.Clear();
            MostrarTablaCredito();
            CalculoLabels();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id_producto = Convert.ToInt32(cmbProductos.SelectedValue);
                DataProduct.ListProductos = n_Ventas.Datafactura(id_producto);

                string producto = DataProduct.ListProductos[0].Producto;
                string codigo = DataProduct.ListProductos[0].CodigoProducto;
                int idcategoria = DataProduct.ListProductos[0].Idcategoria;
                decimal precioVenta = DataProduct.ListProductos[0].PrecioVenta;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal subtotalProduct = cantidad * precioVenta;

                if (cantidad <= DataProduct.ListProductos[0].Stock)
                {
                    if (cantidad > 0)
                    {
                        bool validador = false;
                        foreach (var item in DataVentas.ListDetalle_v)
                        {
                            if (item.Idproducto == id_producto)
                            {
                                validador = true;
                            }
                        }
                        if (!validador)
                        {
                            DataVentas.ListDetalle_v.Add(new E_Detalle_Ventas
                            {
                                CodigoProd = codigo,
                                Preciocompra = precioVenta,
                                Cantidad = cantidad,
                                Subtotal = subtotalProduct,
                                Idproducto = id_producto,
                                Producto = producto,
                                IdCategoria = idcategoria
                            });
                            txtCantidad.Text = "";

                            MostrarTablaCredito();
                            CalculoLabels();
                        }
                        else
                        {
                            FrmWarning.AdvertenciaForm("ESTE PRODUCTO YA FUE AGREGADO");
                        }
                    }
                    else
                    {
                        FrmWarning.AdvertenciaForm("CANTIDAD DEBE SER MAYOR A 0");
                    }
                }
                else
                {
                    FrmWarning.AdvertenciaForm("STOCK INSUFICIENTE");
                    txtCantidad.Text = "";
                }
            }
            catch (Exception)
            {
                FrmWarning.AdvertenciaForm("INGRESE LA CANTIDAD DEL PRODUCTO");
            }
        }

        private decimal PagoWithInteres()
        {
            decimal totalneto = 0;
            if (DataVentas.ListDetalle_v.Count > 0)
            {
                decimal interes = 5;
                decimal total = totalpago - Convert.ToDecimal(txtInicialDePago.Text);
                decimal totalinteres = total * (interes / 100);
                totalneto = ((Convert.ToInt16(txtCuotasEnMeses.Text) * totalinteres) + total);
            }
            return totalneto;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInicialDePago.Text != "" && txtCuotasEnMeses.Text != "")
                {
                    if(txtNombreGarante.Text != "" && txtApellidoGarante.Text != "" && txtCedulaGarante.Text != "")
                    {
                        e_Ventas.Fecha = DateTime.Now;
                        e_Ventas.Total = Convert.ToDecimal(PagoWithInteres() + int.Parse(txtInicialDePago.Text));
                        e_Ventas.Nombre_cliente = cmbClientes.GetItemText(this.cmbClientes.SelectedItem);
                        e_Ventas.Idusuario = DataUser.idusuario;
                        e_Ventas.Idgarante = null;

                        n_Ventas.InsertarVentas(e_Ventas, DataVentas.ListDetalle_v);

                        N_Garante n_Garante = new N_Garante();
                        n_Garante.InsertarGarante(DatosGarante());

                        int idVentas = n_Ventas.ObtenerID();
                        int idGarante = n_Garante.ObtenerID();
                        int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);

                        E_Pagos e_Pagos = new E_Pagos();
                        e_Pagos.Estado = "En Curso";
                        e_Pagos.IdVenta = idVentas;
                        e_Pagos.IdCliente = idCliente;
                        e_Pagos.IdGarante = idGarante;

                        N_Pagos n_Pagos = new N_Pagos();
                        n_Pagos.InsertarPagos(e_Pagos);
                        int idPago = n_Pagos.ObtenerID();

                        Cuotas cuotas = new Cuotas(totalpago, Convert.ToDecimal(txtInicialDePago.Text), Convert.ToInt32(txtCuotasEnMeses.Text));
                        
                        E_Credito credito = new E_Credito();
                        N_Credito n_Credito = new N_Credito();
                        foreach(E_Credito c in DataCredito.ListCredito)
                        {
                            credito.No_Pago = c.No_Pago;
                            credito.Fecha = c.Fecha;
                            credito.Cuotas = c.Cuotas;
                            credito.Capital = c.Capital;
                            credito.Interes = c.Interes;
                            credito.Mora = c.Mora;
                            credito.IdPago = idPago;

                            n_Credito.InsertarCredito(credito);
                        }

                        FrmSuccess.ConfirmacionForm("PAGO EXITOSO");
                        Factura.Contado(e_Ventas, DataProduct.ListProductos);
                        LimpiarFacturacion();
                    }
                    else
                    {
                        FrmWarning.AdvertenciaForm("LLENE LOS DATOS OBLIGATRORIOS DE GARANTE");
                    }
                }
                else
                {
                    if (txtCuotasEnMeses.Text == "")
                    {
                        FrmWarning.AdvertenciaForm("DEBE INGRESAR LAS CUOTAS EN MESES");
                    }
                    else
                    {
                        FrmWarning.AdvertenciaForm("DEBE INGRESAR EL INICIAL DE PAGO");
                    }
                }
            }
            catch
            {
                FrmWarning.AdvertenciaForm("EL PAGO NO PUDO SER PROCESADO");
            }
        }

        private void TablaFactCredito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TablaFactCredito.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
                {
                    Form message = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL PRODUCTO?");
                    DialogResult result = message.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        int delete = Convert.ToInt32(TablaFactCredito.Rows[e.RowIndex].Cells[10].Value.ToString());
                        foreach (var items in DataVentas.ListDetalle_v.ToArray())
                        {
                            if (items.Idproducto == delete)
                            {
                                TablaFactCredito.DataSource = null;
                                DataVentas.ListDetalle_v.Remove(items);
                            }
                        }
                        MostrarTablaCredito();
                        CalculoLabels();
                        FrmSuccess.ConfirmacionForm("ELIMINADO");
                    }
                }
                else if (TablaFactCredito.Rows[e.RowIndex].Cells["EDITAR"].Selected)
                {
                    int id = Convert.ToInt32(TablaFactCredito.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString());
                    DataProduct.ListProductos = n_Ventas.Datafactura(id);

                    FrmMantenimientoFactContado frm = new FrmMantenimientoFactContado();
                    frm.txtCodigo.Text = TablaFactCredito.Rows[e.RowIndex].Cells["CODIGOPROD"].Value.ToString();
                    frm.txtIdProductos.Text = TablaFactCredito.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString();
                    frm.txtNombreProducto.Text = TablaFactCredito.Rows[e.RowIndex].Cells["PRODUCTO"].Value.ToString();
                    frm.txtCantidad.Text = TablaFactCredito.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.Stock = DataProduct.ListProductos[0].Stock;

                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MostrarTablaCredito();
                        CalculoLabels();
                        FrmSuccess.ConfirmacionForm("CANTIDAD MODIFICADA");
                    }
                }
                else if (TablaFactCredito.Rows[e.RowIndex].Cells["DESCUENTO_PRO"].Selected)
                {
                    decimal precioventa;
                    N_Categoria categoria = new N_Categoria();
                    int id = Convert.ToInt32(TablaFactCredito.Rows[e.RowIndex].Cells[13].Value.ToString());
                    DataProduct.ListCategoria = categoria.BuscarCategoriasXID(id);

                    decimal tl = Convert.ToDecimal(TablaFactCredito.Rows[e.RowIndex].Cells["PRECIOCOMPRA"].Value.ToString());
                    decimal descuentoentabla = (tl * (DataProduct.ListCategoria[0].Porciento_Descuento / 100));

                    FrmDescuento frm = new FrmDescuento();
                    frm.txtCodigo.Text = TablaFactCredito.Rows[e.RowIndex].Cells["CODIGOPROD"].Value.ToString();
                    frm.txtIdProductos.Text = TablaFactCredito.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString();
                    frm.txtNombreProducto.Text = TablaFactCredito.Rows[e.RowIndex].Cells["PRODUCTO"].Value.ToString();
                    frm.txtPrecioVenta.Text = (
                        precioventa = Convert.ToDecimal(
                            TablaFactCredito.Rows[e.RowIndex].Cells["PRECIOCOMPRA"].Value.ToString()
                            )
                        ).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO"));
                    frm.txtDescuento.Text = Math.Round(descuentoentabla, 2).ToString();
                    frm.DescuentoMax = Math.Round(descuentoentabla, 2);

                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MostrarTablaCredito();
                        CalculoLabels();
                        FrmSuccess.ConfirmacionForm("DESCUENTO APLICADO");
                    }
                }
            }
            catch (Exception)
            {
                FrmWarning.AdvertenciaForm("ALGO SALIÓ MAL");
            }
        }

        private void txtCuotasEnMeses_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCuotasEnMeses.Text.Length > 0)
                {
                    txtInicialDePago.Enabled = true;
                }
                else if(Convert.ToInt16(txtCuotasEnMeses.Text) == 0)
                {
                    txtInicialDePago.Enabled = false;
                }
            }
            catch
            {
                txtCuotasEnMeses.Text = "";
            }
        }

        private void txtInicialDePago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtInicialDePago.Text.Length > 0)
                {
                    txtCuotasEnMeses.Enabled = false;
                } else if(Convert.ToDecimal(txtInicialDePago.Text) > 0)
                {
                    txtCuotasEnMeses.Enabled = false;
                }
                if(DataVentas.ListDetalle_v.Count > 0)
                {
                    lblRestante.Text = PagoWithInteres().ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
                    decimal cuotas = PagoWithInteres() / Convert.ToInt16(txtCuotasEnMeses.Text);
                    lblcuotas.Text = cuotas.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
                    lblInicial.Text = Convert.ToDecimal(txtInicialDePago.Text).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
                }
            }
            catch
            {
                txtInicialDePago.Text = "";
                lblRestante.Text = "0.00";
                lblInicial.Text = "0.00";
                lblcuotas.Text = "0.00";
                txtCuotasEnMeses.Enabled = true;
            }
        }

        private E_Garante DatosGarante()
        {
            E_Garante garante = new E_Garante();
            garante.Nombre = txtNombreGarante.Text;
            garante.Apellido = txtApellidoGarante.Text;
            garante.Cedula = txtCedulaGarante.Text;
            garante.Telefono = txtTelefonoGarante.Text;
            garante.Celular = txtCelularGarante.Text;
            garante.Direccion = txtDireccionGarante.Text;
            garante.Trabajo = txtTrabajoGarante.Text;
            garante.Sueldo = Convert.ToDecimal(txtSueldoGarante.Text);
            
            return garante;
        }
    }
}