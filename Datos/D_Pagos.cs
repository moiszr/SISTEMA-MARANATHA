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
    public class D_Pagos
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //public List<E_Pagos> ListaPagos(string buscar)
        //{
        //    SqlDataReader reader = null;
        //    SqlCommand cmd = new SqlCommand("SP_BUSCAR_PAGOS", conn);

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    conn.Open();

        //    cmd.Parameters.AddWithValue("@BUSCAR", buscar);

        //    reader = cmd.ExecuteReader();

        //    List<E_Pagos> Listar = new List<E_Pagos>();

        //    while (reader.Read())
        //    {
        //        Listar.Add(new E_Pagos
        //        {
        //            IdPagos = reader.GetInt32(0),
        //            Codigo = reader.GetString(1),
        //            Fecha = reader.GetDateTime(2),
        //            Nombre = reader.GetString(3),
        //            Interes_Mora = reader.GetDecimal(4),
        //            Cuota = reader.GetDecimal(5),
        //            Mora = reader.GetDecimal(6),
        //            Total = reader.GetDecimal(7),
        //            Idcredito = reader.GetInt32(8),
        //            Idcliente = reader.GetInt32(9),

        //        } );
        //    }
        //    conn.Close();
        //    reader.Close();
        //    return Listar;
        //}

        public List<E_Pagos> ListarPagos()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PAGOS", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            reader = cmd.ExecuteReader();

            List<E_Pagos> Listar = new List<E_Pagos>();

            while (reader.Read())
            {
                Listar.Add(new E_Pagos
                {
                    Idpagos = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Estado = reader.GetString(2),
                    Codigoventa = reader.GetString(3),
                    Cliente = reader.GetString(4),
                    Cedula = reader.GetString(5),
                    Garante = reader.GetString(6),
                    IdVenta = reader.GetInt32(7),
                    IdCliente = reader.GetInt32(8),
                    IdGarante = reader.GetInt32(9)
                });
            }
            conn.Close();
            reader.Close();
            return Listar;
        }

        public int ObtenerID()
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_OBTENER_ID_PAGOS";

            conn.Open();
            int ID = (int)cmd.ExecuteScalar();
            conn.Close();
            return ID;
        }

        public void InsertarPagos(E_Pagos pagos)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_PAGOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@ESTADO", pagos.Estado);
            cmd.Parameters.AddWithValue("@IDVENTA", pagos.IdVenta);
            cmd.Parameters.AddWithValue("@IDCLIENTE", pagos.IdCliente);
            cmd.Parameters.AddWithValue("@IDGARANTE", pagos.IdGarante);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //public void EditarPagos(E_Pagos pagos)
        //{
        //    SqlCommand cmd = new SqlCommand("SP_EDIT_CREDITO", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    conn.Open();

        //    cmd.Parameters.AddWithValue("@IDPAGOS", pagos.IdPagos);
        //    cmd.Parameters.AddWithValue("@FECHA", pagos.Fecha);
        //    cmd.Parameters.AddWithValue("@NOMBRE", pagos.Nombre);
        //    cmd.Parameters.AddWithValue("@INTERES_MORA", pagos.Interes_Mora);
        //    cmd.Parameters.AddWithValue("@CUOTA", pagos.Cuota);
        //    cmd.Parameters.AddWithValue("@MORA", pagos.Mora);
        //    cmd.Parameters.AddWithValue("@TOTAL", pagos.Total);
        //    cmd.Parameters.AddWithValue("@IDCREDIO", pagos.Idcredito);
        //    cmd.Parameters.AddWithValue("@IDCLIENTE", pagos.Idcliente);

        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}