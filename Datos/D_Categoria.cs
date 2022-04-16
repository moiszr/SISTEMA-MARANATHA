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
    public class D_Categoria
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        
        public List<E_Categoria>ListaCategorias(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();

            while(reader.Read())
            {
                Listar.Add(new E_Categoria
                {
                    IdCategoria = reader.GetInt32(0),
                    CodigoCategoria = reader.GetString(1),
                    NombreCategoria = reader.GetString(2),
                    DescripcionCategoria = reader.GetString(3),
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.DescripcionCategoria);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.DescripcionCategoria);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCategoria);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
