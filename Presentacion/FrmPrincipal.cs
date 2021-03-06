using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {

            InitializeComponent();
            lblIdentificador.Text = "DASHBOARD";
        }

        public void PantallaOk()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        public void SeleccionBotones(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnDashboard.Textcolor = Color.FromArgb(180, 180, 180);
            btnFacturacionContado.Textcolor = Color.FromArgb(180, 180, 180);
            btnFacturacionRedito.Textcolor = Color.FromArgb(180, 180, 180);
            btnPagar.Textcolor = Color.FromArgb(180, 180, 180);
            btnProductos.Textcolor = Color.FromArgb(180, 180, 180);
            btnVentas.Textcolor = Color.FromArgb(180, 180, 180);
            btnCompras.Textcolor = Color.FromArgb(180, 180, 180);
            btnClientes.Textcolor = Color.FromArgb(180, 180, 180);
            btnUsuarios.Textcolor = Color.FromArgb(180, 180, 180);
            btnLogout.Textcolor = Color.FromArgb(180, 180, 180);

            sender.selected = true;

            if(sender.selected)
            {
                sender.Textcolor = Color.FromArgb(50, 165, 241);
                sender.Activecolor = Color.FromArgb(34, 60, 83);
            }
        }

        private Form formActivado = null;

        private void AbrirFormEnWrapper(Form formHijo)
        {
            if(formActivado != null)
                formActivado.Close();
            formActivado = formHijo;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            Wrapper.Controls.Add(formHijo);
            Wrapper.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            PantallaOk();
            AbrirFormEnWrapper(new FrmDashboard());
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmInformation("¿SEGURO QUE DESEA SALIR DEL SISTEMA?");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmDashboard());
            lblIdentificador.Text = "DASHBOARD";
        }

        private void btnFacturacionRedito_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmFacturacionRedito());
            lblIdentificador.Text = "FACTURACIÓN RÉDITO";
        }

        private void btnFacturacionContado_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmFacturacionContado());
            lblIdentificador.Text = "FACTURACIÓN CONTADO";
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmPagos());
            lblIdentificador.Text = "PAGOS";
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmProductos());
            lblIdentificador.Text = "PRODUCTOS";
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmVentas());
            lblIdentificador.Text = "VENTAS";
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmCompras());
            lblIdentificador.Text = "COMPRAS";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmClientes());
            lblIdentificador.Text = "CLIENTES";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmUsuarios());
            lblIdentificador.Text = "USUARIOS";
        }

        private void bntPagoF_Click(object sender, EventArgs e)
        {
            SeleccionBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormEnWrapper(new FrmPagosFactura());
            lblIdentificador.Text = "PAGO FACTURA";
        }


    }
}
