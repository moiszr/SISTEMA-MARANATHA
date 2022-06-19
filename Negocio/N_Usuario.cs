using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class N_Usuario
    {

        D_Usuario objMarca = new D_Usuario();

        public List<E_Usuario> ListaUsuario(string buscar)
        {
            return objMarca.ListaUsuario(buscar);
        }

        public void InsertarUsuario(E_Usuario Rol)
        {
            objMarca.InsertarUsuario(Rol);
        }

        public void EditarUsuario(E_Usuario Rol)
        {
            objMarca.EditarUsuario(Rol);
        }

        public void EliminarUsuario(E_Usuario Rol)
        {
            objMarca.EliminarUsuario(Rol);
        }
    }
}
