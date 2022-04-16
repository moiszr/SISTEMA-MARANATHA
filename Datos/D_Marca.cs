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
    public class D_Marca
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Marca> ListaMarcas(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Marca> Listar = new List<E_Marca>();

            while (reader.Read())
            {
                Listar.Add(new E_Marca
                {
                    IdMarca = reader.GetInt32(0),
                    CodigoMarca = reader.GetString(1),
                    NombreMarca = reader.GetString(2),
                    DescripcionMarca = reader.GetString(3),
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarMarca(E_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.DescripcionMarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarMarca(E_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDMarca", Marca.IdMarca);
            cmd.Parameters.AddWithValue("@NOMBRE", Marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.DescripcionMarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarMarca(E_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDMarca", Marca.IdMarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
