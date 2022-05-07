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
    public class D_Usuario
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Usuario> ListaUsuario(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Usuario> Listar = new List<E_Usuario>();

            while (reader.Read())
            {
                Listar.Add(new E_Usuario
                {
                    Idusuario = reader.GetInt32(0),
                    Usario = reader.GetString(1),
                    Contraseña = reader.GetString(2),
                    Idrol = reader.GetInt32(3),
                    Idempleado = reader.GetInt32(4),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarUsuario(E_Usuario Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@USUARIO", Usuario.Usario);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", Usuario.Contraseña);
            cmd.Parameters.AddWithValue("@IDROL", Usuario.Idrol);
            cmd.Parameters.AddWithValue("@IDEMPLEADO", Usuario.Idempleado);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarUsuario(E_Usuario Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


            cmd.Parameters.AddWithValue("@IDUSUARIO ", Usuario.Idusuario);
            cmd.Parameters.AddWithValue("@USUARIO", Usuario.Usario);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", Usuario.Contraseña);
            cmd.Parameters.AddWithValue("@IDROL", Usuario.Idrol);
            cmd.Parameters.AddWithValue("@IDEMPLEADO", Usuario.Idempleado);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarUsuario(E_Usuario Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDUSUARIO  ", Usuario.Idusuario);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
