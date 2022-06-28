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

        public List<E_Compras> ListaCompra()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_MOSTRAR_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            reader = cmd.ExecuteReader();
            List<E_Compras> Listar = new List<E_Compras>();

            while (reader.Read())
            {
                Listar.Add(new E_Compras
                {
                    Idcompra = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Proveedor = reader.GetString(2),
                    Usuario = reader.GetString(3),
                    Fecha = reader.GetDateTime(4),
                    Total = reader.GetDecimal(5)
                    
                });
            }
            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarCompra(E_Compras Compra, List<E_Detalle_Compras> e_Detalle_Compras)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", Compra.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL", Compra.Total);
            cmd.Parameters.AddWithValue("@PROVEEDOR", Compra.Proveedor);
            cmd.Parameters.AddWithValue("@IDUSUARIO", Compra.Idusuario);
           

            cmd.ExecuteNonQuery();

            var cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SP_OBTENER_ID_COMPRA";

            int ID = (int)cmd2.ExecuteScalar();
            conn.Close();

            D_Detalle_Compras d_Detalle = new D_Detalle_Compras();
            foreach (E_Detalle_Compras DCompra in e_Detalle_Compras)
            {
                d_Detalle.InsertarDetalle_Compras(DCompra, ID);
                
            }
        }
    }
}
