using System;
using System.Collections.Generic;
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
    public partial class FrmVentas : Form
    {
        N_Ventas nventas = new N_Ventas();

        public FrmVentas()
        {
            InitializeComponent();
            MostarTabla();
        }

        public void MostarTabla()
        {
             N_Ventas nventas = new N_Ventas();

            TablaVentas.DataSource = nventas.ListarVentas("");

        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            this.Hide();
            frm.ShowDialog();
        }

        private void TablaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
