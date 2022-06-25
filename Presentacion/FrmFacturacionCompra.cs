using System;
using Presentacion.Data;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace Presentacion
{
    public partial class FrmFacturacionCompra : Form
    {
        N_Compras n_Compra = new N_Compras();
        E_Compras e_Compra = new E_Compras();
        N_Ventas n_Ventas = new N_Ventas();

        private decimal totalpago;

        public FrmFacturacionCompra()
        {
            InitializeComponent();
            LimpiarListas();
            ListarProducto();
        }

        private void btnVerProductos_Click(object sender, EventArgs e)
        {
            FrmVistaProductos frm = new FrmVistaProductos();
            frm.ShowDialog();
        }

        private void LimpiarListas()
        {
            DataProduct.ListCategoria.Clear();
            DataProduct.ListProductos.Clear();
            DataCompra.ListDetalle_c.Clear();
        }
        public void ListarProducto()
        {
            N_Productos nproductos = new N_Productos();
            cmbProducto.DataSource = nproductos.ListarProductos();
            cmbProducto.ValueMember = "IdProductos";
            cmbProducto.DisplayMember = "Producto";
        }

        public void MostrarTablaCompra()
        {
            TablaFactContado.DataSource = null;
            TablaFactContado.DataSource = DataCompra.ListDetalle_c;
            OcultarMoverAncharColumnas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id_producto = Convert.ToInt32(cmbProducto.SelectedValue);
                DataProduct.ListProductos = n_Ventas.Datafactura(id_producto);

                string producto = DataProduct.ListProductos[0].Producto;
                decimal precioCompra = DataProduct.ListProductos[0].PrecioCompra;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal subtotalProduct = cantidad * precioCompra;

                if (cantidad > 0)
                {
                    bool validador = false;
                    foreach (var item in DataCompra.ListDetalle_c)
                    {
                        if (item.Idproducto == id_producto)
                        {
                            validador = true;
                        }
                    }
                    if (!validador)
                    {
                        DataCompra.ListDetalle_c.Add(new E_Detalle_Compras
                        {
                            Preciocompra = precioCompra,
                            Cantidad = cantidad,
                            Subtotal = subtotalProduct,
                            Idproducto = id_producto,
                            Producto = producto,
                        });
                        txtCantidad.Text = "";
                        MostrarTablaCompra();
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
            catch (Exception)
            {
                FrmWarning.AdvertenciaForm("INGRESE LA CANTIDAD DEL PRODUCTO");
            }

        }
        public void OcultarMoverAncharColumnas()
        {
            TablaFactContado.Columns[0].Visible = false;
            TablaFactContado.Columns[2].Visible = false;
            TablaFactContado.Columns[3].Visible = false;
            TablaFactContado.Columns[8].Visible = false;
            TablaFactContado.Columns[9].DisplayIndex = 0;

            TablaFactContado.Columns[10].DisplayIndex = 1;
            TablaFactContado.Columns[5].DisplayIndex = 2;
            TablaFactContado.Columns[6].DisplayIndex = 3;
            TablaFactContado.Columns[7].DisplayIndex = 4;
            TablaFactContado.Columns[1].DisplayIndex = 5;

            TablaFactContado.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[5].Width = 207;
            TablaFactContado.Columns[5].ReadOnly = true;

            TablaFactContado.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[6].Width = 198;
            TablaFactContado.Columns[6].ReadOnly = true;

            TablaFactContado.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaFactContado.Columns[7].Width = 210;
            TablaFactContado.Columns[7].ReadOnly = true;


        }

        private void CalculoLabels()
        {
            decimal subtotal = 0, total = 0;

            foreach (var item in DataCompra.ListDetalle_c)
            {
                subtotal += item.Subtotal;
            }
            total = subtotal;
            totalpago = total;

            lblSubtotal.Text = subtotal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
            lblTotal.Text = total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-DO")).PadRight(20);
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
                        int delete = Convert.ToInt32(TablaFactContado.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString());
                        foreach (var items in DataCompra.ListDetalle_c.ToArray())
                        {
                            if (items.Idproducto == delete)
                            {
                                TablaFactContado.DataSource = null;
                                DataCompra.ListDetalle_c.Remove(items);
                            }
                        }
                        MostrarTablaCompra();
                        CalculoLabels();
                        FrmSuccess.ConfirmacionForm("ELIMINADO");
                    }
                }
               
            }
            catch (Exception)
            {
                FrmWarning.AdvertenciaForm("ALGO SALIÓ MAL");
            }
        }

    private void LimpiarFacturacion()
        {
            txtProveeores.Text = "";
            cmbProducto.Text = "";
            txtCantidad.Text = "";
            DataCompra.ListDetalle_c.Clear();
            MostrarTablaCompra();
            CalculoLabels();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (totalpago > 0 && txtProveeores.Text != "")
                {
                    e_Compra.Fecha = DateTime.Now;
                    e_Compra.Total = totalpago;
                    e_Compra.Proveedor = txtProveeores.Text;
                    e_Compra.Idusuario = DataUser.idusuario;
                    FrmSuccess.ConfirmacionForm("COMPRA GUARDA");

                    n_Compra.InsertarCompras(e_Compra, DataCompra.ListDetalle_c);

                    FrmSuccess.ConfirmacionForm("COMPRA GUARDA");
                    LimpiarFacturacion();
                }
                else
                {
                    if (txtProveeores.Text == "")
                    {
                        FrmWarning.AdvertenciaForm("DEBE COLOCAR UN PROVEEDOR");
                    }
                    else
                    {
                        FrmWarning.AdvertenciaForm("EL PAGO EN EFECTIVO ES INSUFICIENTE");
                    }
                }
            }
            catch
            {
                FrmWarning.AdvertenciaForm("DEBE INGRESAR REVISAR LOS CAMPOS");
            }

        }

    }
}

