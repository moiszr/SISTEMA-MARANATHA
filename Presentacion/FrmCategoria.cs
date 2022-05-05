using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmCategoria : Form
    {
        private string IDCategoria;
        private bool Editarse = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            MostrarBuscarTabla("");
            AccionesTable();
        }

        public void AccionesTable()
        {
            tblCategoria.Columns[0].Visible = false;
            tblCategoria.Columns[1].Width = 90;
            tblCategoria.Columns[2].Width = 190;

            tblCategoria.ClearSelection();
        }

        public void LimpiarCajas()
        {
            lblCode.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
        }

        public void MostrarBuscarTabla(string buscar)
        {
            tblCategoria.DataSource = objNegocio.ListarCategorias(buscar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MostrarBuscarTabla(txtSearch.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tblCategoria.ClearSelection();
            Editarse = false;
            LimpiarCajas();
            txtName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(tblCategoria.SelectedRows.Count > 0)
            {
                Editarse = true;
                IDCategoria = tblCategoria.CurrentRow.Cells[0].Value.ToString();
                lblCode.Text = tblCategoria.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = tblCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescription.Text = tblCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Editarse == false)
            {
                try
                {
                    objEntidad.NombreCategoria = txtName.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescription.Text.ToUpper();

                    objNegocio.InsertarCategoria(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarBuscarTabla("");
                    LimpiarCajas();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }

            if(Editarse == true)
            {
                try
                {
                    objEntidad.IdCategoria = Convert.ToInt32(IDCategoria);
                    objEntidad.NombreCategoria = txtName.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescription.Text.ToUpper();

                    objNegocio.EditarCategoria(objEntidad);

                    MessageBox.Show("Se edito el registro");
                    MostrarBuscarTabla("");
                    LimpiarCajas();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tblCategoria.SelectedRows.Count > 0)
            {
                objEntidad.IdCategoria = Convert.ToInt32(tblCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminarCategoria(objEntidad);

                MessageBox.Show("Se elimino el registro correctamente");
                MostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea eliminar");
            }    
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            worksheet = workbook.Sheets[1];
            worksheet.Name = "Categorias";

            for (int i = 1; i < tblCategoria.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = tblCategoria.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < tblCategoria.Rows.Count; i++)
            {
                for (int j = 0; j < tblCategoria.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = tblCategoria.Rows[i].Cells[j].Value.ToString();
                }
            }

            app.Visible = true;
        }
    }
}
