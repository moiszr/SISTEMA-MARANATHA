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
    public partial class FrmMantenimientoProductos : Form
    {
        FrmProductos frm = new FrmProductos();
        E_Productos entidades = new E_Productos();
        N_Productos negocio = new N_Productos();

        public bool Update = false;

        public FrmMantenimientoProductos()
        {
            InitializeComponent();
            ListarCategorias();
            ListarMarcas();
        }

        public void ListarCategorias()
        {
            N_Categoria nCategoria = new N_Categoria();
            cmbCategorias.DataSource = nCategoria.ListarCategorias("");
            cmbCategorias.ValueMember = "IdCategoria";
            cmbCategorias.DisplayMember = "NombreCategoria";
        }

        public void ListarMarcas()
        {
            N_Marca nCategoria = new N_Marca();
            cmbMarcas.DataSource = nCategoria.ListarMarca("");
            cmbMarcas.ValueMember = "IdMarca";
            cmbMarcas.DisplayMember = "NombreMarca";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Update == false)
            {
                try
                {
                    entidades.Producto = txtNombreProducto.Text.ToUpper();
                    entidades.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidades.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidades.Stock = Convert.ToInt32(txtStock.Text);
                    entidades.Idcategoria = Convert.ToInt32(cmbCategorias.SelectedValue);
                    entidades.Idmarca = Convert.ToInt32(cmbMarcas.SelectedValue);

                    negocio.InsertandoProductos(entidades);

                    FrmSuccess.ConfirmacionForm("PRODUCTO GUARDADO");

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el producto" + ex);
                }
            }
            if (Update == true)
            {
                try
                {
                    entidades.IdProductos = Convert.ToInt32(txtIdProductos.Text);
                    entidades.Producto = txtNombreProducto.Text.ToUpper();
                    entidades.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidades.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidades.Stock = Convert.ToInt32(txtStock.Text);
                    entidades.Idcategoria = Convert.ToInt32(cmbCategorias.SelectedValue);
                    entidades.Idmarca = Convert.ToInt32(cmbMarcas.SelectedValue);

                    negocio.EditandoProdcutos(entidades);

                    FrmSuccess.ConfirmacionForm("PRODUCTO EDITADO");

                    Close();

                    Update = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el producto" + ex);
                }
            }
        }
    }
}
