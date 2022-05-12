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
    public class D_Ventas
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Ventas> ListaVenta(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Ventas> Listar = new List<E_Ventas>();

            while (reader.Read())
            {
                Listar.Add(new E_Ventas
                {
                    Idventa = reader.GetInt32(0),
                    Fecha = reader.GetDateTime(1),
                    Total = reader.GetInt32(2),
                    Idempleados = reader.GetInt32(3),
                    Idcliente = reader.GetInt32(4),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarUsuario(E_Ventas Ventas)
        {
            SqlCommand cmd = new SqlCommand("SP_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", Ventas.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL", Ventas.Total);
            cmd.Parameters.AddWithValue("@IDEMPLEADO", Ventas.Idempleados);
            cmd.Parameters.AddWithValue("@IDCLIENTE", Ventas.Idcliente);

            cmd.ExecuteNonQuery();
            conn.Close();
        }



    }
}
