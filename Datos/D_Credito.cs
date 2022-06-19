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

        public List<E_Credito> ListaCredito(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Credito> Listar = new List<E_Credito>();

            while (reader.Read())
            {
                Listar.Add(new E_Credito
                {
                    IdCredito = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Fecha = reader.GetDateTime(2),
                    Total_Venta = reader.GetDecimal(3),
                    Interes = reader.GetDecimal(4),
                    Tiempo = reader.GetInt32(5),
                    CuotasPagadas = reader.GetInt32(6),
                    Cuota = reader.GetDecimal(7),
                    Total_Pagado = reader.GetDecimal(8),
                    Total_pagar = reader.GetDecimal(9),
                    Idventa = reader.GetInt32(10),
                    Idcliente = reader.GetInt32(11),
                
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarCredito(E_Credito credito)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", credito.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL_VENTA", credito.Total_Venta);
            cmd.Parameters.AddWithValue("@INTERES", credito.Interes);
            cmd.Parameters.AddWithValue("@TIEMPO", credito.Tiempo); 
            cmd.Parameters.AddWithValue("@CUOTAS_PAGADAS", credito.CuotasPagadas);
            cmd.Parameters.AddWithValue("@CUOTA", credito.Cuota); 
            cmd.Parameters.AddWithValue("@TOTAL_PAGADO", credito.Total_Pagado);
            cmd.Parameters.AddWithValue("@TOTAL_PAGAR", credito.Total_pagar); 
            cmd.Parameters.AddWithValue("@IDVENTA", credito.Idventa);
            cmd.Parameters.AddWithValue("@IDCLIENTE", credito.Idcliente); 
         
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarCredito(E_Credito credito)
        {
            SqlCommand cmd = new SqlCommand("SP_EDIT_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDCREDIO", credito.IdCredito);
            cmd.Parameters.AddWithValue("@FECHA", credito.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL_VENTA", credito.Total_Venta);
            cmd.Parameters.AddWithValue("@INTERES", credito.Interes);
            cmd.Parameters.AddWithValue("@TIEMPO", credito.Tiempo);
            cmd.Parameters.AddWithValue("@CUOTAS_PAGADAS", credito.CuotasPagadas);
            cmd.Parameters.AddWithValue("@CUOTA", credito.Cuota);
            cmd.Parameters.AddWithValue("@TOTAL_PAGADO", credito.Total_Pagado);
            cmd.Parameters.AddWithValue("@TOTAL_PAGAR", credito.Total_pagar);
            cmd.Parameters.AddWithValue("@IDVENTA", credito.Idventa);
            cmd.Parameters.AddWithValue("@IDCLIENTE", credito.Idcliente);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarCredito(E_Credito credito)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDCREDIO", credito.IdCredito);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
