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

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
       
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

   

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuser_enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
            }
        }

        private void txtuser_leave(object sender, EventArgs e)
        {
            if(txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";

            }
        }

        private void txtpass_enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.UseSystemPasswordChar = false;

            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            List<E_login> entidades = new List<E_login>();
            N_Usuario negocio = new N_Usuario();

            
            entidades = negocio.VerificarLogin(txtuser.Text, txtpass.Text);

            if (entidades.Count != 0)
                {
                DataUser.idusuario = entidades[0].Idusuario;
                DataUser.usuario = entidades[0].Usario;
                DataUser.nombre = entidades[0].Nombre;
                DataUser.apellido = entidades[0].Apellido;
                DataUser.rol = entidades[0].Idrol;

                FrmPrincipal frm = new FrmPrincipal();

                this.Hide();
                frm.ShowDialog();


            }
            else
            {
                FrmSuccess.ConfirmacionForm("USUARIO O CONTRASEÑA INCORRECTA");
                txtpass.Text = "CONTRASEÑA";
                txtpass.UseSystemPasswordChar = false;
                txtuser.Text = "USUARIO";

            }






        }
    }
}
