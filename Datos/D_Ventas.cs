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
                    Nombre_cliente = reader.GetString(3),
                    Idusuario = reader.GetInt32(4),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarVentas(E_Ventas Ventas, List<E_Detalle_Ventas> e_Detalle_Ventas)
        {
            SqlCommand cmd = new SqlCommand("SP_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", Ventas.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL", Ventas.Total);
            cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", Ventas.Nombre_cliente);
            cmd.Parameters.AddWithValue("@IDUSUARIO", Ventas.Idusuario);

            cmd.ExecuteNonQuery();

            var cmd2 = conn.CreateCommand();

            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.CommandText = "SP_OBTENER_ID_VENTA";

            int ID = (int)cmd2.ExecuteScalar();
            conn.Close();




            foreach (E_Detalle_Ventas DVentas in e_Detalle_Ventas)
            {
                InsertarDetalle_Ventas(DVentas, ID);
            }

        }
        public void InsertarDetalle_Ventas(E_Detalle_Ventas DetalleVentas, int id)
        {
            SqlCommand cmd = new SqlCommand("SP_DETALLE_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            
                cmd.Parameters.AddWithValue("@PRECIOVENTA", DetalleVentas.Preciocompra);
                cmd.Parameters.AddWithValue("@CANTIDAD", DetalleVentas.Cantidad);
                cmd.Parameters.AddWithValue("@SUBTOTAL", DetalleVentas.Subtotal);
                cmd.Parameters.AddWithValue("@IDVENTA", id);
                cmd.Parameters.AddWithValue("@IDPRODUCTO", DetalleVentas.Idproducto);
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<E_Productos> Datafactura(int id)
        {

              SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_DATA_FACTURA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@ID", id);

            reader = cmd.ExecuteReader();

            List<E_Productos> Listar = new List<E_Productos>();

            while (reader.Read())
            {
                Listar.Add(new E_Productos
                {

                    IdProductos = reader.GetInt32(0),
                    CodigoProducto = reader.GetString(1),
                    Producto = reader.GetString(2),
                    PrecioCompra = reader.GetDecimal(3),
                    PrecioVenta = reader.GetDecimal(4),
                    Stock = reader.GetInt32(5),
                    Idcategoria = reader.GetInt32(6),
                    Idmarca = reader.GetInt32(7),


                });
            }

            conn.Close();
            reader.Close();

            return Listar;
            
        }

    }
}
