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
    public class N_Usuario
    {

        D_Usuario objuUsuario = new D_Usuario();

        public DataTable ListandoCliente()
        {
            return objuUsuario.ListarUsuario();
        }

        public DataTable BuscarUsuarios(string buscar)
        {
            return objuUsuario.BuscarUsuario(buscar);
        }

        public void InsertarUsuario(E_Usuario Rol)
        {
            objuUsuario.InsertarUsuario(Rol);
        }

        public void EditarUsuario(E_Usuario Rol)
        {
            objuUsuario.EditarUsuario(Rol);
        }

        public void EliminarUsuario(int id)
        {
            objuUsuario.EliminarUsuario(id);
        }

        public List<E_login> VerificarLogin(string usuario, string contraseña)
        {
            return objuUsuario.VerificarLogin(usuario, contraseña);
        }

    }
}
