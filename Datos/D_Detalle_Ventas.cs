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
    public class D_Detalle_Ventas
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        public List<E_Detalle_Ventas> ListaDetalle_Ventas(int id)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DETALLE_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@ID", id);

            reader = cmd.ExecuteReader();

            List<E_Detalle_Ventas> Listar = new List<E_Detalle_Ventas>();

            while (reader.Read())
            {
                Listar.Add(new E_Detalle_Ventas
                {
                    Codigo = reader.GetString(0),
                    CodigoVent = reader.GetString(1),
                    Producto = reader.GetString(2),
                    Preciocompra = reader.GetDecimal(3),
                    Cantidad = reader.GetInt32(4),
                    Descuento = reader.GetDecimal(5),
                    Subtotal = reader.GetDecimal(6),
                });
            }
            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarDetalle_Ventas(E_Detalle_Ventas DetalleVentas, int id)
        {
            SqlCommand cmd = new SqlCommand("SP_DETALLE_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@PRECIOVENTA", DetalleVentas.Preciocompra);
            cmd.Parameters.AddWithValue("@CANTIDAD", DetalleVentas.Cantidad);
            cmd.Parameters.AddWithValue("@DESCUENTO", DetalleVentas.Descuento);
            cmd.Parameters.AddWithValue("@SUBTOTAL", DetalleVentas.Subtotal);
            cmd.Parameters.AddWithValue("@IDVENTA", id);
            cmd.Parameters.AddWithValue("@IDPRODUCTO", DetalleVentas.Idproducto);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
