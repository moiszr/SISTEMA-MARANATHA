using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Empleado
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Empleados> ListaEmpleados(string buscar)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_EMPLEADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            reader = cmd.ExecuteReader();

            List<E_Empleados> Listar = new List<E_Empleados>();

            while (reader.Read())
            {
                Listar.Add(new E_Empleados
                {
                    Idempleado = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Apellido = reader.GetString(2),
                    Cedula = reader.GetString(3),
                    Telefono = reader.GetString(4),
                    Direccion = reader.GetString(5),
              
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarEmpleados(E_Empleados Empleados)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_EMPLEADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Empleados.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Empleados.Apellido);
            cmd.Parameters.AddWithValue("@CEDULA", Empleados.Cedula);
            cmd.Parameters.AddWithValue("@TELEFONO", Empleados.Telefono);
            cmd.Parameters.AddWithValue("@DIRECION", Empleados.Direccion);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarEmpleados(E_Empleados Empleados)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_EMPLEADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDEMPLEADO ", Empleados.Idempleado);
            cmd.Parameters.AddWithValue("@NOMBRE", Empleados.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Empleados.Apellido);
            cmd.Parameters.AddWithValue("@CEDULA", Empleados.Cedula);
            cmd.Parameters.AddWithValue("@TELEFONO", Empleados.Telefono);
            cmd.Parameters.AddWithValue("@DIRECION", Empleados.Direccion);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarEmpleados(E_Empleados Empleados)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_EMPLEADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("@IDEMPLEADO ", Empleados.Idempleado);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
