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

        public List<E_Ventas> ListaVenta()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_MOSTRAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            reader = cmd.ExecuteReader();
            List<E_Ventas> Listar = new List<E_Ventas>();

            while (reader.Read())
            {
                Listar.Add(new E_Ventas
                {
                    Idventa = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Nombre_cliente = reader.GetString(2),
                    Usuario = reader.GetString(3),
                    Fecha = reader.GetDateTime(4),
                    Total = reader.GetDecimal(5)
                });
            }
            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarVentas(E_Ventas Ventas, List<E_Detalle_Ventas> e_Detalle_Ventas)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", Ventas.Fecha);
            cmd.Parameters.AddWithValue("@TOTAL", Ventas.Total);
            cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", Ventas.Nombre_cliente);
            cmd.Parameters.AddWithValue("@IDUSUARIO", Ventas.Idusuario);
            if(Ventas.Idgarante == null)
            {
                cmd.Parameters.AddWithValue("@IDGARANTE", DBNull.Value);
            } else
            {
                cmd.Parameters.AddWithValue("@IDGARANTE", Ventas.Idgarante);
            }
            cmd.ExecuteNonQuery();

            var cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SP_OBTENER_ID_VENTA";

            int ID = (int)cmd2.ExecuteScalar();
            conn.Close();

            D_Detalle_Ventas d_Detalle = new D_Detalle_Ventas();
            foreach (E_Detalle_Ventas DVentas in e_Detalle_Ventas)
            {
                d_Detalle.InsertarDetalle_Ventas(DVentas, ID);
            }
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
