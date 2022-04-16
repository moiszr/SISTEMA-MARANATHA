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
    public partial class FrmMarca : Form
    {
        private string IDMarca;
        private bool Editarse = false;

        E_Marca objEntidad = new E_Marca();
        N_Marca objNegocio = new N_Marca();

        public FrmMarca()
        {
            InitializeComponent();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            MostrarBuscarTabla("");
            AccionesTable();
        }

        public void AccionesTable()
        {
            tblMarca.Columns[0].Visible = false;
            tblMarca.Columns[1].Width = 90;
            tblMarca.Columns[2].Width = 190;

            tblMarca.ClearSelection();
        }

        public void LimpiarCajas()
        {
            lblCode.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
        }

        public void MostrarBuscarTabla(string buscar)
        {
            tblMarca.DataSource = objNegocio.ListarMarca(buscar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MostrarBuscarTabla(txtSearch.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tblMarca.ClearSelection();
            Editarse = false;
            LimpiarCajas();
            txtName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tblMarca.SelectedRows.Count > 0)
            {
                Editarse = true;
                IDMarca = tblMarca.CurrentRow.Cells[0].Value.ToString();
                lblCode.Text = tblMarca.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = tblMarca.CurrentRow.Cells[2].Value.ToString();
                txtDescription.Text = tblMarca.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.NombreMarca = txtName.Text.ToUpper();
                    objEntidad.DescripcionMarca = txtDescription.Text.ToUpper();

                    objNegocio.InsertarMarca(objEntidad);

                    FrmSuccess.ConfirmacionForm("GUARDADO");
                    MostrarBuscarTabla("");
                    LimpiarCajas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }

            if (Editarse == true)
            {
                try
                {
                    objEntidad.IdMarca = Convert.ToInt32(IDMarca);
                    objEntidad.NombreMarca = txtName.Text.ToUpper();
                    objEntidad.DescripcionMarca = txtDescription.Text.ToUpper();

                    objNegocio.EditarMarca(objEntidad);

                    FrmSuccess.ConfirmacionForm("EDITADO");
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
            try
            {
                DialogResult resultado = new DialogResult();
                FrmInformation frm = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL REGISTRO?");
                resultado = frm.ShowDialog();

                if(resultado == DialogResult.OK)
                {
                    objEntidad.IdMarca = Convert.ToInt32(tblMarca.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.EliminarMarca(objEntidad);

                    FrmSuccess.ConfirmacionForm("ELIMINADO");
                    MostrarBuscarTabla("");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Seleccione la fila que desea eliminar" + ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
