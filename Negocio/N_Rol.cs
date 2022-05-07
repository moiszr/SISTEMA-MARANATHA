using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;


namespace Negocio
{
    internal class N_Rol
    {
        D_Rol objMarca = new D_Rol();

        public List<E_Rol> ListaRol(string buscar)
        {
            return objMarca.ListaRol(buscar);
        }

        public void InsertarRol(E_Rol Rol)
        {
            objMarca.InsertarRol(Rol);
        }

        public void EditarRol(E_Rol Rol)
        {
            objMarca.EditarRol(Rol);
        }

        public void EliminarRol(E_Rol Rol)
        {
            objMarca.EliminarRol(Rol);
        }
    }
}
