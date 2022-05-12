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
        public List<E_Detalle_Ventas> ListaVenta(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCARDETALLEVENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Detalle_Ventas> Listar = new List<E_Detalle_Ventas>();

            while (reader.Read())
            {
                Listar.Add(new E_Detalle_Ventas
                {
                    IDdetalleventa = reader.GetInt32(0),
                    Preciocompra = reader.GetDecimal(1),
                    Cantidad = reader.GetInt32(2),
                    Subtotal = reader.GetDecimal(3),
                    Idventa = reader.GetInt32(4),
                    Idproducto = reader.GetInt32(5),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarUsuario(E_Detalle_Ventas DetalleVentas)
        {
            SqlCommand cmd = new SqlCommand("SP_DETALLE_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@PRECIOCOMPRA", DetalleVentas.Preciocompra);
            cmd.Parameters.AddWithValue("@CANTIDAD", DetalleVentas.Cantidad);
            cmd.Parameters.AddWithValue("@SUBTOTAL", DetalleVentas.Subtotal);
            cmd.Parameters.AddWithValue("@IDCOMPRA", DetalleVentas.Idventa);
            cmd.Parameters.AddWithValue("@IDPRODUCTO", DetalleVentas.Idproducto);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
