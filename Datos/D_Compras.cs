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
    public class D_Compras
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);


        public List<E_Compras> ListaVenta(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCOMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Compras> Listar = new List<E_Compras>();

            while (reader.Read())
            {
                Listar.Add(new E_Compras
                {
                    Idcompra = reader.GetInt32(0),
                    Fecha = reader.GetDateTime(1),
                    Total = reader.GetInt32(2),
                    Idempleados = reader.GetInt32(3),
                    Idproveedores = reader.GetInt32(4),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarUsuario(E_Compras Compras)
        {
            SqlCommand cmd = new SqlCommand("SP_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", Compras.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL", Compras.Total);
            cmd.Parameters.AddWithValue("@IDEMPLEADO", Compras.Idempleados);
            cmd.Parameters.AddWithValue("@IDPROVEEDORES", Compras.Idproveedores);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
