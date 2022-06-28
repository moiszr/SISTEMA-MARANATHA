using System;
using Presentacion.Data;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace Presentacion
{
    public partial class FrmFacturacionContado : Form
    {
        N_Ventas n_Ventas = new N_Ventas();
        E_Ventas e_Ventas = new E_Ventas();

        private decimal efectivo;
        private decimal totalpago;

        public FrmFacturacionContado()
        {
            InitializeComponent();
            LimpiarListas();
            ListarProducto();
        }

        public void OcultarMoverAncharColumnas()
        {
            TablaFactContado.Columns[3].Visible = false;
            TablaFactContado.Columns[4].Visible = false;
            TablaFactContado.Columns[9].Visible = false;
            TablaFactContado.Columns[10].Visible = false;
            TablaFactContado.Columns[13].Visible = false;

            TablaFactContado.Columns[12].DisplayIndex = 0;
            TablaFactContado.Columns[11].DisplayIndex = 1;
            TablaFactContado.Columns[5].DisplayIndex = 2;
            TablaFactContado.Columns[6].DisplayIndex = 3;
            TablaFactContado.Columns[7].DisplayIndex = 4;
            TablaFactContado.Columns[8].DisplayIndex = 5;
            TablaFactContado.Columns[1].DisplayIndex = 6;
            TablaFactContado.Columns[0].DisplayIndex = 6;
            TablaFactContado.Columns[2].DisplayIndex = 6;

            TablaFactContado.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[12].Width = 155;

            TablaFactContado.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[11].Width = 275;
            TablaFactContado.Columns[11].ReadOnly = true;

            TablaFactContado.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[5].Width = 207;
            TablaFactContado.Columns[5].ReadOnly = true;

            TablaFactContado.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[6].Width = 198;
            TablaFactContado.Columns[6].ReadOnly = true;

            TablaFactContado.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[7].Width = 210;
            TablaFactContado.Columns[7].ReadOnly = true;

            TablaFactContado.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[8].Width = 220;
            TablaFactContado.Columns[8].ReadOnly = true;
        }

        private void LimpiarListas()
        {
            DataProduct.ListCategoria.Clear();
            DataProduct.ListProductos.Clear();
            DataVentas.ListDetalle_v.Clear();
        }

        public void ListarProducto()
        {
            N_Productos nproductos = new N_Productos();
            cmbProducto.DataSource = nproductos.ListarProductos();
            cmbProducto.ValueMember = "IdProductos";
            cmbProducto.DisplayMember = "Producto";
        }

        public void MostrarTablaContado()
        {
            TablaFactContado.DataSource = null;
            TablaFactContado.DataSource = DataVentas.ListDetalle_v;
            OcultarMoverAncharColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id_producto = Convert.ToInt32(cmbProducto.SelectedValue);
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

                            MostrarTablaContado();
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
            catch(Exception)
            {
                FrmWarning.AdvertenciaForm("INGRESE LA CANTIDAD DEL PRODUCTO");
            }
        }

        private void CalculoLabels()
        {
            decimal subtotal = 0, itbis = 0, descuento = 0, total = 0;

            foreach (var item in DataVentas.ListDetalle_v)
            {
                subtotal += item.Subtotal;
                descuento += (item.Descuento * item.Cantidad);
            }
            total = subtotal + itbis - descuento;
            totalpago = total;

            lblSubtotal.Text = subtotal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblDescuento.Text = descuento.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblTotal.Text = total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
        }

        private void LimpiarFacturacion()
        {
            txtCliente.Text = "";
            cmbProducto.Text = "";
            txtCantidad.Text = "";
            txtPagoEnEfectivo.Text = "";
            lblDevuelta.Text = "0.00";

            DataVentas.ListDetalle_v.Clear();
            MostrarTablaContado();
            CalculoLabels();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtPagoEnEfectivo.Text) >= totalpago && txtCliente.Text != "")
                {
                    e_Ventas.Fecha = DateTime.Now;
                    e_Ventas.Total = totalpago;
                    e_Ventas.Nombre_cliente = txtCliente.Text;
                    e_Ventas.Idusuario = DataUser.idusuario;
                    e_Ventas.Idgarante = null;

                    n_Ventas.InsertarVentas(e_Ventas, DataVentas.ListDetalle_v);

                    FrmSuccess.ConfirmacionForm("PAGO EXITOSO");
                    Factura.Contado(e_Ventas, DataProduct.ListProductos);
                    LimpiarFacturacion();
                }
                else
                {
                    if (txtCliente.Text == "")
                    {
                        FrmWarning.AdvertenciaForm("DEBE COLOCAR UN CLIENTE");
                    }
                    else
                    {
                        FrmWarning.AdvertenciaForm("EL PAGO EN EFECTIVO ES INSUFICIENTE");
                    }
                }
            } 
            catch
            {
                FrmWarning.AdvertenciaForm("DEBE INGRESAR UNA CANTIDAD DE PAGO");
            }
        }

        private void txtPagoEnEfectivo_TextChanged(object sender, EventArgs e)
        {
            efectivo = 0;
            try
            {
                if (txtPagoEnEfectivo.Text.Length > 0)
                    efectivo = Convert.ToDecimal(txtPagoEnEfectivo.Text);
                lblDevuelta.Text = "$" + (efectivo - totalpago).ToString();
            }
            catch
            {
                txtPagoEnEfectivo.Text = "";
                FrmWarning.AdvertenciaForm("DEBE INGRESAR LA CANTIDAD EN EFECTIVO");
            }
        }

        private void TablaFactContado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TablaFactContado.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
                {
                    Form message = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL PRODUCTO?");
                    DialogResult result = message.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        int delete = Convert.ToInt32(TablaFactContado.Rows[e.RowIndex].Cells[10].Value.ToString());
                        foreach (var items in DataVentas.ListDetalle_v.ToArray())
                        {
                            if (items.Idproducto == delete)
                            {
                                TablaFactContado.DataSource = null;
                                DataVentas.ListDetalle_v.Remove(items);
                            }
                        }
                        MostrarTablaContado();
                        CalculoLabels();
                        FrmSuccess.ConfirmacionForm("ELIMINADO");
                    }
                }
                else if (TablaFactContado.Rows[e.RowIndex].Cells["EDITAR"].Selected)
                {
                    int id = Convert.ToInt32(TablaFactContado.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString());
                    DataProduct.ListProductos = n_Ventas.Datafactura(id);

                    FrmMantenimientoFactContado frm = new FrmMantenimientoFactContado();
                    frm.txtCodigo.Text = TablaFactContado.Rows[e.RowIndex].Cells["CODIGOPROD"].Value.ToString();
                    frm.txtIdProductos.Text = TablaFactContado.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString();
                    frm.txtNombreProducto.Text = TablaFactContado.Rows[e.RowIndex].Cells["PRODUCTO"].Value.ToString();
                    frm.txtCantidad.Text = TablaFactContado.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.Stock = DataProduct.ListProductos[0].Stock;

                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MostrarTablaContado();
                        CalculoLabels();
                        FrmSuccess.ConfirmacionForm("CANTIDAD MODIFICADA");
                    }
                }
                else if (TablaFactContado.Rows[e.RowIndex].Cells["DESCUENTO_PRO"].Selected)
                {
                    decimal precioventa;
                    N_Categoria categoria = new N_Categoria();
                    int id = Convert.ToInt32(TablaFactContado.Rows[e.RowIndex].Cells[13].Value.ToString());
                    DataProduct.ListCategoria = categoria.BuscarCategoriasXID(id);

                    decimal tl = Convert.ToDecimal(TablaFactContado.Rows[e.RowIndex].Cells["PRECIOCOMPRA"].Value.ToString());
                    decimal descuentoentabla = (tl * (DataProduct.ListCategoria[0].Porciento_Descuento / 100));

                    FrmDescuento frm = new FrmDescuento();
                    frm.txtCodigo.Text = TablaFactContado.Rows[e.RowIndex].Cells["CODIGOPROD"].Value.ToString();
                    frm.txtIdProductos.Text = TablaFactContado.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString();
                    frm.txtNombreProducto.Text = TablaFactContado.Rows[e.RowIndex].Cells["PRODUCTO"].Value.ToString();
                    frm.txtPrecioVenta.Text = (
                        precioventa = Convert.ToDecimal(
                            TablaFactContado.Rows[e.RowIndex].Cells["PRECIOCOMPRA"].Value.ToString()
                            )
                        ).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO"));
                    frm.txtDescuento.Text = Math.Round(descuentoentabla, 2).ToString();
                    frm.DescuentoMax = Math.Round(descuentoentabla, 2);

                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MostrarTablaContado();
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

        private void btnVerProductos_Click(object sender, EventArgs e)
        {
            FrmVistaProductos frm = new FrmVistaProductos();
            frm.ShowDialog();
        }
    }
}
