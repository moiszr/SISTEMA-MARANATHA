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
    public class D_Credito
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Credito> ListarCredito(int id)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@ID", id);

            reader = cmd.ExecuteReader();

            List<E_Credito> Listar = new List<E_Credito>();

            while (reader.Read())
            {
                Listar.Add(new E_Credito
                {
                    Idcredito = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    No_Pago = reader.GetInt32(2),
                    Fecha = reader.GetDateTime(3),
                    Cuotas = reader.GetDecimal(4),
                    Capital = reader.GetDecimal(5),
                    Interes = reader.GetDecimal(6),
                    Mora = reader.GetDecimal(7),
                    Estado = reader.GetString(8),
                    IdPago = reader.GetInt32(9)
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarCredito(E_Credito credito)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@NO_PAGO", credito.No_Pago);
            cmd.Parameters.AddWithValue("@FECHA", credito.Fecha);
            cmd.Parameters.AddWithValue("@CUOTAS", credito.Cuotas);
            cmd.Parameters.AddWithValue("@CAPITAL", credito.Capital);
            cmd.Parameters.AddWithValue("@INTERES", credito.Interes);
            cmd.Parameters.AddWithValue("@MORA", credito.Mora);
            
            cmd.Parameters.AddWithValue("@IDPAGO", credito.IdPago);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
