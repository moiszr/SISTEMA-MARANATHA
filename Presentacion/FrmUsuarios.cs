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
    public partial class FrmUsuarios : Form
    {

        N_Usuario negocio = new N_Usuario();
        E_Usuario entidades = new E_Usuario();


        public FrmUsuarios()
        {
            InitializeComponent();
            MostrarUsuario();
        }

        public void MostrarUsuario()
        {
            TablaUsuario.DataSource = negocio.ListandoCliente();
        }

        public void BuscarUsuario(string buscar)
        {
            TablaUsuario.DataSource = negocio.BuscarUsuarios(buscar);

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuario(txtSearch.Text);
        }
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmMantenimientoUsuarios frm = new FrmMantenimientoUsuarios();
            frm.ShowDialog();
            frm.Update = false;
            MostrarUsuario();

        }

        private void TablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (TablaUsuario.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {
                Form message = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL USUARIO?");
                DialogResult result = message.ShowDialog();

                if (result == DialogResult.OK)
                {
                    int delete = Convert.ToInt32(TablaUsuario.Rows[e.RowIndex].Cells[2].Value.ToString());
                    negocio.EliminarUsuario(delete);
                    FrmSuccess.ConfirmacionForm("ELIMINADO");
                    MostrarUsuario();
                }
            }
            else if (TablaUsuario.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                FrmMantenimientoUsuarios frm = new FrmMantenimientoUsuarios();
                frm.Update = true;
                frm.txtCodigo.Text = TablaUsuario.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                frm.txtIdUsusario.Text = TablaUsuario.Rows[e.RowIndex].Cells["IDUSUARIO"].Value.ToString();
                frm.txtNombre.Text = TablaUsuario.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                frm.txtApellido.Text = TablaUsuario.Rows[e.RowIndex].Cells["APELLIDO"].Value.ToString();
                frm.txtUsuario.Text = TablaUsuario.Rows[e.RowIndex].Cells["USUARIO"].Value.ToString();
                frm.txtContraseña1.Text = TablaUsuario.Rows[e.RowIndex].Cells["CONTRASEÑA"].Value.ToString();
                frm.txtContraseña2.Text = TablaUsuario.Rows[e.RowIndex].Cells["CONTRASEÑA"].Value.ToString();
                frm.cmbRoles.Text = TablaUsuario.Rows[e.RowIndex].Cells["ROL"].Value.ToString();

                frm.lblNombre.Text = "EDITAR PRODUCTO";

                frm.ShowDialog();

                MostrarUsuario();

            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
