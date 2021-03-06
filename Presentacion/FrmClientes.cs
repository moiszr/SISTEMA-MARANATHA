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
    public partial class FrmClientes : Form
    {
        N_Cliente negocio = new N_Cliente();
        E_Cliente entidades = new E_Cliente();

        public FrmClientes()
        {
            InitializeComponent();
            MostrarTablaClientes();
            OcultarMoverAncharColumnas();
        }
        public void OcultarMoverAncharColumnas()
        {
            TablaClientes.Columns[2].Visible = false;
            TablaClientes.Columns[7].Visible = false;
            TablaClientes.Columns[9].Visible = false;
            TablaClientes.Columns[12].Visible = false;
            TablaClientes.Columns[13].Visible = false;
            TablaClientes.Columns[14].Visible = false;
            TablaClientes.Columns[15].Visible = false;
            TablaClientes.Columns[16].Visible = false;
            TablaClientes.Columns[17].Visible = false;
            TablaClientes.Columns[18].Visible = false;
            TablaClientes.Columns[19].Visible = false;
            TablaClientes.Columns[20].Visible = false;
            TablaClientes.Columns[21].Visible = false;
            TablaClientes.Columns[22].Visible = false;
            TablaClientes.Columns[23].Visible = false; 
            TablaClientes.Columns[24].Visible = false;
            TablaClientes.Columns[25].Visible = false;
            TablaClientes.Columns[26].Visible = false;
            TablaClientes.Columns[27].Visible = false;
            TablaClientes.Columns[28].Visible = false;
            TablaClientes.Columns[29].Visible = false;
            TablaClientes.Columns[30].Visible = false;
            TablaClientes.Columns[31].Visible = false;
            TablaClientes.Columns[32].Visible = false;

            TablaClientes.Columns[0].DisplayIndex = 11;
            TablaClientes.Columns[1].DisplayIndex = 11;

            TablaClientes.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[3].Width = 140;

            TablaClientes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[4].Width = 170;

            TablaClientes.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[5].Width = 170;

            TablaClientes.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[6].Width = 160;

            TablaClientes.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[8].Width = 160;

            TablaClientes.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[10].Width = 160;

            TablaClientes.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TablaClientes.Columns[11].Width = 260;



        }


        public void MostrarTablaClientes()
        {
            TablaClientes.DataSource = negocio.ListandoCliente();
            MostrarTotal();
        }
        public void MostrarTotal()
        {

        }

        public void BuscarCliente(string buscar)
        {
            TablaClientes.DataSource = negocio.BuscandoCliente(buscar);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente(txtSearch.Text);
        }

        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            FrmMantenimientoClientes1 frm = new FrmMantenimientoClientes1();

            frm.ShowDialog();
            frm.Update = false;
            MostrarTablaClientes();
        }

        private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaClientes.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {
                Form message = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL CLIENTE?");
                DialogResult result = message.ShowDialog();

                if(result == DialogResult.OK)
                {
                    int delete = Convert.ToInt32(TablaClientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                    negocio.EliminarCliente(delete);
                    FrmSuccess.ConfirmacionForm("ELIMINADO");
                    MostrarTablaClientes();
                }
            }

            else if (TablaClientes.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                FrmMantenimientoClientes1 frm = new FrmMantenimientoClientes1();
                FrmMantenimientoClientes2 frm2 = new FrmMantenimientoClientes2();

                frm2.Update = true;
                frm.Update = true;
                frm2.Idcliente = Convert.ToInt32(TablaClientes.Rows[e.RowIndex].Cells["IDCLIENTE"].Value.ToString());
                frm.txtIdCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                frm.txtNombreCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                frm.txtApellidoCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["APELLIDO"].Value.ToString();
                frm.txtCedula.Text = TablaClientes.Rows[e.RowIndex].Cells["CEDULA"].Value.ToString();
                frm.txtApodoCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["APODO"].Value.ToString();
                frm.txtTelefonoResidencial.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONO1"].Value.ToString();
                frm.txtOtroTelefono.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONO2"].Value.ToString();
                frm.txtTelefonoCelularCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["CELULAR"].Value.ToString();
                frm.txtDireccion.Text = TablaClientes.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
                frm.txtLugarDeTrabajo.Text = TablaClientes.Rows[e.RowIndex].Cells["LUGARDETRABAJO"].Value.ToString();
                frm.txtTelefonoTrabajo.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONOTRABAJO"].Value.ToString();
                frm.txtNombredelSuperiorInmediato.Text = TablaClientes.Rows[e.RowIndex].Cells["NOMBRESUPERIOR"].Value.ToString();
                frm.txtTelefonoDelSuperiorInmediato.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONOSUPERIOR"].Value.ToString();
                frm.txtTiempoLaborando.Text = TablaClientes.Rows[e.RowIndex].Cells["TIEMPOLABORANDO"].Value.ToString();
                frm.txtSalarioMensual.Text = TablaClientes.Rows[e.RowIndex].Cells["SALARIOMENSUAL"].Value.ToString();
                frm.txtNombreDelConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["NOMBRECONYUGUE"].Value.ToString();
                frm.txtTelefonoDelConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONOCONYUGUE"].Value.ToString();
                frm.txtTelefonoDeTrabajoDelConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["TRABAJOCONYUGUE"].Value.ToString();
                frm.txtTelefonoDeTrabajoDelConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONOTRABAJOCONYUGUE"].Value.ToString();
                frm.txtNombreDelSuperiorConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["NOMBRESUPERIORCONYUGUE"].Value.ToString();
                frm.txtTelefonoSuperiorConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["TELEFONOSUPERIORCONYUGUE"].Value.ToString();
                frm.txtTiempoLaborandoConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["TIEMPOLABORANDOCONYUGUE"].Value.ToString();
                frm.txtSalarioMensualConyugue.Text = TablaClientes.Rows[e.RowIndex].Cells["SalarioMensualConyugue"].Value.ToString();
                frm2.txtNombreReferenciaPer1.Text = TablaClientes.Rows[e.RowIndex].Cells["Nombre_Apellido_Telefono_Referencia1"].Value.ToString();
                frm2.txtNombreReferenciaPer2.Text = TablaClientes.Rows[e.RowIndex].Cells["Nombre_Apellido_Telefono_Referencia2"].Value.ToString();
                frm2.txtNombreReferenciaPer3.Text = TablaClientes.Rows[e.RowIndex].Cells["Nombre_Apellido_Telefono_Referencia3"].Value.ToString();
                frm2.txtNombreFamilaresCerc1.Text = TablaClientes.Rows[e.RowIndex].Cells["Nombre_Apellido_Telefono_Familiar1"].Value.ToString();
                frm2.txtNombreFamilaresCerc2.Text = TablaClientes.Rows[e.RowIndex].Cells["Nombre_Apellido_Telefono_Familiar2"].Value.ToString();
                frm2.txtNombreFamilaresCerc3.Text = TablaClientes.Rows[e.RowIndex].Cells["Nombre_Apellido_Telefono_Familiar3"].Value.ToString();
                frm.lblNombre.Text = "EDITAR PRODUCTO";

                frm.ShowDialog();
                MostrarTablaClientes();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            worksheet = workbook.Sheets[1];
            worksheet.Name = "Clientes";

            for (int i = 1; i < TablaClientes.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = TablaClientes.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < TablaClientes.Rows.Count; i++)
            {
                for (int j = 0; j < TablaClientes.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = TablaClientes.Rows[i].Cells[j].Value.ToString();
                }
            }

            app.Visible = true;
        }
    }
}
