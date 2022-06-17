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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            FrmMantenimientoClientes1 frm = new FrmMantenimientoClientes1();
            frm.ShowDialog();
            //frm.Update = false;
        }
    }
}
