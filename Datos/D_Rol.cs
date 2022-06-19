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
        public class D_Rol
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Rol> ListaRol(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_ROL", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Rol> Listar = new List<E_Rol>();

            while (reader.Read())
            {
                Listar.Add(new E_Rol
                {
                    Idrol = reader.GetInt32(0),
                    Rol = reader.GetString(1),

                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarRol(E_Rol Rol)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ROL", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@ROL ", Rol.Rol);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarRol(E_Rol Rol)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_ROL", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDROL ", Rol.Idrol);
            cmd.Parameters.AddWithValue("@ROL ", Rol.Rol);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarRol(E_Rol Rol)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ROL", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDROL ", Rol.Idrol);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
