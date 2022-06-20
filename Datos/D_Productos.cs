using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class D_Productos
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable ListarProductos()
        {
            DataTable table = new DataTable();
            SqlDataReader sqlReader;
            SqlCommand cmd = new SqlCommand("SP_LISTARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            sqlReader = cmd.ExecuteReader();
            table.Load(sqlReader);

            sqlReader.Close();
            conn.Close();

            return table;
        }

        public DataTable BuscarProductos(E_Productos productos)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", productos.Buscar);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            conn.Close();
            return table;
        }

        public void EliminarProducto(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDPRODUCTO", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertarProductos(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARPRODUCTOS", conn);
            cmd.CommandType= CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@PRODUCTO", productos.Producto);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", productos.PrecioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_VENTA", productos.PrecioVenta);
            cmd.Parameters.AddWithValue("@STOCK", productos.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", productos.Idcategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", productos.Idmarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarProductos(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDPRODUCTO", productos.IdProductos);
            cmd.Parameters.AddWithValue("@PRODUCTO", productos.Producto);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", productos.PrecioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_VENTA", productos.PrecioVenta);
            cmd.Parameters.AddWithValue("@STOCK", productos.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", productos.Idcategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", productos.Idmarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void MostrarTotal(E_Productos producto)
        {
            SqlCommand cmd = new SqlCommand("SP_TOTALESPRODUCT", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter totalCategorias = new SqlParameter("@TOTALCATEGORIA", 0);
            totalCategorias.Direction = ParameterDirection.Output;

            SqlParameter totalMarcas = new SqlParameter("@TOTALMARCA", 0);
            totalMarcas.Direction = ParameterDirection.Output;

            SqlParameter totalProdcutos = new SqlParameter("@TOTALPRODUCTO", 0);
            totalProdcutos.Direction = ParameterDirection.Output;

            SqlParameter totalStock = new SqlParameter("@SUMSTOCK", 0);
            totalStock.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(totalCategorias);
            cmd.Parameters.Add(totalMarcas);
            cmd.Parameters.Add(totalProdcutos);
            cmd.Parameters.Add(totalStock);
            conn.Open();

            cmd.ExecuteNonQuery();

            producto.TotalCategoria = cmd.Parameters["@TOTALCATEGORIA"].Value.ToString();
            producto.Totalmarca = cmd.Parameters["@TOTALMARCA"].Value.ToString();
            producto.TotalProductos = cmd.Parameters["@TOTALPRODUCTO"].Value.ToString();
            producto.TotalStock = cmd.Parameters["@SUMSTOCK"].Value.ToString();

            conn.Close();
        }


        public List<E_Productos> ListarProductoCB()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_LISTARPRODUC", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


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