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
    public partial class FrmProductos : Form
    {
        N_Productos negocio = new N_Productos();
        E_Productos entidades = new E_Productos();

        public FrmProductos()
        {
            InitializeComponent();
            MostrarTablaProductos();
            OcultarMoverAncharColumnas();
        }

        public void OcultarMoverAncharColumnas()
        {
            TablaProductos.Columns[2].Visible = false;
            TablaProductos.Columns[5].Visible = false;
            TablaProductos.Columns[7].Visible = false;

            TablaProductos.Columns[0].DisplayIndex = 11;
            TablaProductos.Columns[1].DisplayIndex = 11;

            TablaProductos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaProductos.Columns[3].Width = 150;

            TablaProductos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaProductos.Columns[4].Width = 220;

            TablaProductos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaProductos.Columns[6].Width = 260;

            TablaProductos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaProductos.Columns[0].Width = 80;

            TablaProductos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaProductos.Columns[1].Width = 80;


        }

        public void MostrarTablaProductos()
        {
            TablaProductos.DataSource = negocio.ListandoProductos();
            MostrarTotal();
        }

        public void BuscarProductos(string buscar)
        {
            
            TablaProductos.DataSource = negocio.BuscandoProductos(buscar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos(txtSearch.Text);
        }

        private void btnNueboProducto_Click(object sender, EventArgs e)
        {
            FrmMantenimientoProductos frm = new FrmMantenimientoProductos();
            frm.ShowDialog();
            frm.Update = false;
            MostrarTablaProductos();
        }

        private void TablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(TablaProductos.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {
                Form message = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL PRODUCTO?");
                DialogResult result = message.ShowDialog();

                if(result == DialogResult.OK)
                {
                    int delete = Convert.ToInt32(TablaProductos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    negocio.EliminandoProducto(delete);
                    FrmSuccess.ConfirmacionForm("ELIMINADO");
                    MostrarTablaProductos();
                }
            }
            else if(TablaProductos.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                FrmMantenimientoProductos frm = new FrmMantenimientoProductos();
                frm.Update = true;
                frm.txtCodigo.Text = TablaProductos.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                frm.txtIdProductos.Text = TablaProductos.Rows[e.RowIndex].Cells["IDPRODUCTO"].Value.ToString();
                frm.txtNombreProducto.Text = TablaProductos.Rows[e.RowIndex].Cells["PRODUCTO"].Value.ToString();
                frm.txtPrecioCompra.Text = TablaProductos.Rows[e.RowIndex].Cells["PRECIO_COMPRA"].Value.ToString();
                frm.txtPrecioVenta.Text = TablaProductos.Rows[e.RowIndex].Cells["PRECIO_VENTA"].Value.ToString();
                frm.txtStock.Text = TablaProductos.Rows[e.RowIndex].Cells["STOCK"].Value.ToString();
                frm.cmbCategorias.Text = TablaProductos.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                frm.cmbMarcas.Text = TablaProductos.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();

                frm.lblNombre.Text = "EDITAR PRODUCTO";

                frm.ShowDialog();
                MostrarTablaProductos();
            }
        }

        private void btnFormCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.ShowDialog();
            MostrarTotal();
        }

        private void btnFormMarcas_Click(object sender, EventArgs e)
        {
            FrmMarca frm = new FrmMarca();
            frm.ShowDialog();
            MostrarTotal();
        }

        public void MostrarTotal()
        {
            negocio.SumandoTotales(entidades);
            lblCateogrias.Text = entidades.TotalCategoria;
            lblMarcas.Text = entidades.Totalmarca;
            lblProductos.Text = entidades.TotalProductos;
            lblStock.Text = entidades.TotalStock;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            worksheet = workbook.Sheets[1];
            worksheet.Name = "Productos";

            for(int i = 1; i < TablaProductos.Columns.Count +1; i++)
            {
                worksheet.Cells[1, i] = TablaProductos.Columns[i - 1].HeaderText;
            }

            for(int i = 0; i < TablaProductos.Rows.Count; i++)
            {
                for(int j = 0; j < TablaProductos.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = TablaProductos.Rows[i].Cells[j].Value.ToString();
                }
            }

            app.Visible = true;
        }
    }
}
