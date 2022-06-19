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

        public List<E_Garante> ListaGarante (string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_GARANTE", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Garante> Listar = new List<E_Garante>();

            while (reader.Read())
            {
                Listar.Add(new E_Garante

                {
                    Idgarante = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Fecha = reader.GetDateTime(2),
                    Nombre = reader.GetString(3),
                    Apellido = reader.GetString(4),
                    Cedula = reader.GetString(5),
                    Telefono = reader.GetString(6),
                    Celular = reader.GetString(7),
                    Direccion = reader.GetString(8),
                    Trabajo = reader.GetString(9),
                    Sueldo = reader.GetString(10),

                });
            }
            conn.Close();
            reader.Close();

            return Listar;
        }
        public void InsertarGarante(E_Garante garante)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@FECHA", garante.Fecha);
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

        public void EditarGarante(E_Garante garante)
        {
            SqlCommand cmd = new SqlCommand("SP_EDIT_CREDITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDGARANTE", garante.Idgarante);
            cmd.Parameters.AddWithValue("@FECHA", garante.Fecha);
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

        public void EliminarGarante(E_Garante garante)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_GARANTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDGARANTE", garante.Idgarante);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

   