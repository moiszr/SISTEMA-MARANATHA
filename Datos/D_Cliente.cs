using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entidades;

namespace Datos
{
    public class D_Cliente
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);



        public DataTable ListarClientes()
        {
            DataTable table = new DataTable();
            SqlDataReader sqlReader;
            SqlCommand cmd = new SqlCommand("SP_LISTARCLIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            sqlReader = cmd.ExecuteReader();
            table.Load(sqlReader);

            sqlReader.Close();
            conn.Close();

            return table;
        }
        public DataTable BuscarClientes(string buscar)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CLIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            conn.Close();
       

            return table;
        }

        public void InsertarCliente(E_Cliente Cliente)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CLIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Cliente.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Cliente.Apellido);
            cmd.Parameters.AddWithValue("@CEDULA", Cliente.Cedula);
            cmd.Parameters.AddWithValue("@APODO", Cliente.Apodo);
            cmd.Parameters.AddWithValue("@TELEFONO1", Cliente.Telefono1);
            cmd.Parameters.AddWithValue("@TELEFONO2", Cliente.Telefono2);
            cmd.Parameters.AddWithValue("@CELULAR", Cliente.Celular);
            cmd.Parameters.AddWithValue("@DIRECCION", Cliente.Direccion);
            cmd.Parameters.AddWithValue("@CASA", Cliente.Casa);
            cmd.Parameters.AddWithValue("@LUGARDETRABAJO", Cliente.LugarDeTrabajo);
            cmd.Parameters.AddWithValue("@TELEFONOTRABAJO", Cliente.TelefonoTrabajo);
            cmd.Parameters.AddWithValue("@NOMBRESUPERIOR", Cliente.NombreSuperior);
            cmd.Parameters.AddWithValue("@TELEFONOSUPERIOR", Cliente.TelefonoSuperior);
            cmd.Parameters.AddWithValue("@TIEMPOLABORANDO", Cliente.TiempoLaborando);
            cmd.Parameters.AddWithValue("@SALARIOMENSUAL", Cliente.SalarioMensual);
            cmd.Parameters.AddWithValue("@NOMBRECONYUGUE", Cliente.NombreConyugue);
            cmd.Parameters.AddWithValue("@TELEFONOCONYUGUE", Cliente.TelefonoConyuge);
            cmd.Parameters.AddWithValue("@TRABAJOCONYUGUE", Cliente.TrabajoConyugue);
            cmd.Parameters.AddWithValue("@TELEFONOTRABAJOCONYUGUE", Cliente.TelefonoTrabajoConyugue);
            cmd.Parameters.AddWithValue("@NOMBRESUPERIORCONYUGUE", Cliente.NombreSuperiorConyugue);
            cmd.Parameters.AddWithValue("@TELEFONOSUPERIORCONYUGUE", Cliente.TelefonoSuperiorConyugue);
            cmd.Parameters.AddWithValue("@TIEMPOLABORANDOCONYUGUE", Cliente.TiempoLaborandoConyugue);
            cmd.Parameters.AddWithValue("@SALARIOMENSUALCONYUGUE", Cliente.SalarioMensualConyugue);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_REFERENCIA1", Cliente.Nombre_Apellido_Telefono_Referencia1);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_REFERENCIA2", Cliente.Nombre_Apellido_Telefono_Referencia2);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_REFERENCIA3", Cliente.Nombre_Apellido_Telefono_Referencia3);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_FAMILIAR1", Cliente.Nombre_Apellido_Telefono_Familiar1);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_FAMILIAR2", Cliente.Nombre_Apellido_Telefono_Familiar2);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_FAMILIAR3", Cliente.Nombre_Apellido_Telefono_Familiar3);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarCliente(E_Cliente Cliente)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_CLIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDCliente", 3);
            cmd.Parameters.AddWithValue("@NOMBRE", Cliente.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Cliente.Apellido);
            cmd.Parameters.AddWithValue("@CEDULA", Cliente.Cedula);
            cmd.Parameters.AddWithValue("@APODO", Cliente.Apodo);
            cmd.Parameters.AddWithValue("@TELEFONO1", Cliente.Telefono1);
            cmd.Parameters.AddWithValue("@TELEFONO2", Cliente.Telefono2);
            cmd.Parameters.AddWithValue("@CELULAR", Cliente.Celular);
            cmd.Parameters.AddWithValue("@DIRECCION", Cliente.Direccion);
            cmd.Parameters.AddWithValue("@CASA", Cliente.Casa);
            cmd.Parameters.AddWithValue("@LUGARDETRABAJO", Cliente.LugarDeTrabajo);
            cmd.Parameters.AddWithValue("@TELEFONOTRABAJO", Cliente.TelefonoTrabajo);
            cmd.Parameters.AddWithValue("@NOMBRESUPERIOR", Cliente.NombreSuperior);
            cmd.Parameters.AddWithValue("@TELEFONOSUPERIOR", Cliente.TelefonoSuperior);
            cmd.Parameters.AddWithValue("@TIEMPOLABORANDO", Cliente.TiempoLaborando);
            cmd.Parameters.AddWithValue("@SALARIOMENSUAL", Cliente.SalarioMensual);
            cmd.Parameters.AddWithValue("@NOMBRECONYUGUE", Cliente.NombreConyugue);
            cmd.Parameters.AddWithValue("@TELEFONOCONYUGUE", Cliente.TelefonoConyuge);
            cmd.Parameters.AddWithValue("@TRABAJOCONYUGUE", Cliente.TrabajoConyugue);
            cmd.Parameters.AddWithValue("@TELEFONOTRABAJOCONYUGUE", Cliente.TelefonoTrabajoConyugue);
            cmd.Parameters.AddWithValue("@NOMBRESUPERIORCONYUGUE", Cliente.NombreSuperiorConyugue);
            cmd.Parameters.AddWithValue("@TELEFONOSUPERIORCONYUGUE", Cliente.TelefonoSuperiorConyugue);
            cmd.Parameters.AddWithValue("@TIEMPOLABORANDOCONYUGUE", Cliente.TiempoLaborandoConyugue);
            cmd.Parameters.AddWithValue("@SALARIOMENSUALCONYUGUE", Cliente.SalarioMensualConyugue);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_REFERENCIA1", Cliente.Nombre_Apellido_Telefono_Referencia1);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_REFERENCIA2", Cliente.Nombre_Apellido_Telefono_Referencia2);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_REFERENCIA3", Cliente.Nombre_Apellido_Telefono_Referencia3);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_FAMILIAR1", Cliente.Nombre_Apellido_Telefono_Familiar1);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_FAMILIAR2", Cliente.Nombre_Apellido_Telefono_Familiar2);
            cmd.Parameters.AddWithValue("@NOMBRE_APELLIDO_TELEFONO_FAMILIAR3", Cliente.Nombre_Apellido_Telefono_Familiar3);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarCliente(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CLIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDCliente", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<E_Cliente> ListarClienteCB()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_LISTARCLIENTECMB", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


            reader = cmd.ExecuteReader();

            List<E_Cliente> Listar = new List<E_Cliente>();

            while (reader.Read())
            {
                Listar.Add(new E_Cliente
                {
                    IdCliente = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }
    }
}
