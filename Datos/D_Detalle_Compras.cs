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
    public class D_Detalle_Compras
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Detalle_Compras> ListaDetalle_Compras(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_DETALLE_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Detalle_Compras> Listar = new List<E_Detalle_Compras>();

            while (reader.Read())
            {
                Listar.Add(new E_Detalle_Compras
                {
                    IDdetallecompra = reader.GetInt32(0),
                    Preciocompra = reader.GetDecimal(1),
                    Cantidad = reader.GetInt32(2),
                    Subtotal = reader.GetDecimal(3),
                    Idcompra = reader.GetInt32(4),
                    Idproducto = reader.GetInt32(5),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarDetalle_Compras(E_Detalle_Compras DetalleCompras)
        {
            SqlCommand cmd = new SqlCommand("SP_DETALLE_COMPRA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@PRECIOCOMPRA", DetalleCompras.Preciocompra);
            cmd.Parameters.AddWithValue("@CANTIDAD", DetalleCompras.Cantidad);
            cmd.Parameters.AddWithValue("@SUBTOTAL", DetalleCompras.Subtotal);
            cmd.Parameters.AddWithValue("@IDCOMPRA", DetalleCompras.Idcompra);
            cmd.Parameters.AddWithValue("@IDPRODUCTO", DetalleCompras.Idproducto);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
