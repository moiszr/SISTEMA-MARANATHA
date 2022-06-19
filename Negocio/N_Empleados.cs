using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class N_Empleados
    {
        D_Empleado objDato = new D_Empleado();

        public List<E_Empleados> ListaEmpleados(string buscar)
        {
            return objDato.ListaEmpleados(buscar);
        }

        public void InsertarEmpleados(E_Empleados Empleado)
        {
            objDato.InsertarEmpleados(Empleado);
        }

        public void EditarEmpleados(E_Empleados Empleado)
        {
            objDato.EditarEmpleados(Empleado);
        }

        public void EliminarEmpleados(E_Empleados Empleado)
        {
            objDato.EliminarEmpleados(Empleado);
        }
    }
}
