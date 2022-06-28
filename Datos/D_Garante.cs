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
    public class D_Garante
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Garante> ListarGarante(int id)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_GARANTE", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@ID", id);

            reader = cmd.ExecuteReader();

            List<E_Garante> Listar = new List<E_Garante>();

            while (reader.Read())
            {
                Listar.Add(new E_Garante
                {
                    Idgarante = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Apellido = reader.GetString(3),
                    Cedula = reader.GetString(4),
                    Telefono = reader.GetString(5),
                    Celular = reader.GetString(6),
                    Direccion = reader.GetString(7),
                    Trabajo = reader.GetString(8),
                    Sueldo = reader.GetDecimal(9),
                });
            }
            conn.Close();
            reader.Close();

            return Listar;
        }

        public int ObtenerID()
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_OBTENER_ID_GARANTE";

            conn.Open();
            int ID = (int)cmd.ExecuteScalar();
            conn.Close();
            return ID;
        }

        public void InsertarGarante(E_Garante garante)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_GARANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", garante.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", garante.Apellido);
            cmd.Parameters.AddWithValue("@CEDULA", garante.Cedula);
            cmd.Parameters.AddWithValue("@TELEFONO1", garante.Telefono);
            cmd.Parameters.AddWithValue("@CELULAR", garante.Celular);
            cmd.Parameters.AddWithValue("@DIRECCION", garante.Direccion);
            cmd.Parameters.AddWithValue("@TRABAJO", garante.Trabajo);
            cmd.Parameters.AddWithValue("@SUELDO", garante.Sueldo);
           
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

   