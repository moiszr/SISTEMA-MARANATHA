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
    public class D_PagosFactura
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_PagosFactura> ListaPagosFactura(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCARPAGOFACTURA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_PagosFactura> Listar = new List<E_PagosFactura>();

            while (reader.Read())
            {
                Listar.Add(new E_PagosFactura
                {
                    IdPagoF = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Fecha = reader.GetDateTime(3),
                    Descripcion = reader.GetString(4),
                    CuotasPagadas = reader.GetInt32(5),
                    CuotasFaltante = reader.GetInt32(6),
                    Total = reader.GetDecimal(7),
                    Usuario = reader.GetString(8),
                    Idcliente = reader.GetInt32(9)

                   
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarPagoFactura(E_PagosFactura pagosFactura)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARPAGOFACTURA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", pagosFactura.Fecha);
            cmd.Parameters.AddWithValue("@DESCRIPCION", pagosFactura.Descripcion);
            cmd.Parameters.AddWithValue("@CUOTAS_PAGADAS", pagosFactura.CuotasPagadas);
            cmd.Parameters.AddWithValue("@CUOTAS_FALTANTES", pagosFactura.CuotasFaltante);
            cmd.Parameters.AddWithValue("@TOTAL", pagosFactura.Total);
            cmd.Parameters.AddWithValue("@IDCLIENTE", pagosFactura.Idcliente);
            cmd.Parameters.AddWithValue("@IDUSUARIO", pagosFactura.IdUsuario);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void EliminarPagoFactura(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPAGOFACTURA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDPAGOF", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


    }
}
