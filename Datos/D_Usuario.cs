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

        public DataTable ListarUsuario()
        {
            DataTable table = new DataTable();
            SqlDataReader sqlReader;
            SqlCommand cmd = new SqlCommand("SP_LISTARUSUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            sqlReader = cmd.ExecuteReader();
            table.Load(sqlReader);

            sqlReader.Close();
            conn.Close();

            return table;
        }


        public DataTable BuscarUsuario(string buscar)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();


            cmd.Parameters.AddWithValue("@BUSCAR", buscar);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            conn.Close();

            return table;
        }

        public void InsertarUsuario(E_Usuario Usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@USUARIO", Usuario.Usario);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", Usuario.Contraseña);
            cmd.Parameters.AddWithValue("@IDROL", Usuario.Idrol);
            cmd.Parameters.AddWithValue("@NOMBRE", Usuario.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Usuario.Apellido);


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
            cmd.Parameters.AddWithValue("@NOMBRE", Usuario.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Usuario.Apellido);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarUsuario(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDUSUARIO  ", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<E_login> VerificarLogin(string usuario, string contraseña)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_LOGIN", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", contraseña);

            reader = cmd.ExecuteReader();

            List<E_login> Listar = new List<E_login>();

            while (reader.Read())
            {
                Listar.Add(new E_login
                {
                    Idusuario = reader.GetInt32(0),
                    Nombre = reader.GetString(2),
                    Apellido = reader.GetString(3),
                    Usario = reader.GetString(4),
                    Contraseña = reader.GetString(5),
                    Idrol = reader.GetString(6),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }





    }
}
