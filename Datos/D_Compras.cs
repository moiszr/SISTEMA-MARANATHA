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


        public List<E_Compras> ListaCompra(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_COMPRA", conn);
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
                    Idusuario = reader.GetInt32(3),
                   

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarCompra(E_Compras Compras, List<E_Detalle_Compras> e_Detalle_Compras)
        {
            SqlCommand cmd = new SqlCommand("SP_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", Compras.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL", Compras.Total);
            cmd.Parameters.AddWithValue("@IDUSUARIO", Compras.Idusuario);

            cmd.ExecuteNonQuery();
            var cmd2 = conn.CreateCommand();

            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.CommandText = "SP_OBTENER_ID_COMPRAR";

            int ID = (int)cmd2.ExecuteScalar();
            conn.Close();


            foreach (E_Detalle_Compras DComprar in e_Detalle_Compras)
            {
                InsertarDetalle_Ventas(DComprar, ID);
            }

        }
        public void InsertarDetalle_Ventas(E_Detalle_Compras DetalleCompra, int id)
        {
            SqlCommand cmd = new SqlCommand("SP_DETALLE_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@PRECIOCOMPRA", DetalleCompra.Preciocompra);
            cmd.Parameters.AddWithValue("@CANTIDAD", DetalleCompra.Cantidad);
            cmd.Parameters.AddWithValue("@SUBTOTAL", DetalleCompra.Subtotal);
            cmd.Parameters.AddWithValue("@IDCOMPRA", id);
            cmd.Parameters.AddWithValue("@IDPRODUCTO", DetalleCompra.Idproducto);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
