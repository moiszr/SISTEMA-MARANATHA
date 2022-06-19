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
    public class N_Cliente
    {
        D_Cliente objCliente = new D_Cliente();
        E_Cliente entidades = new E_Cliente();

        public DataTable ListandoCliente()
        {
            return objCliente.ListarClientes();
        }

        public DataTable BuscandoCliente(string buscar)
        {
             
            return objCliente.BuscarClientes(buscar);
        }

        public void InsertarCliente(E_Cliente Cliente)
        {
            objCliente.InsertarCliente(Cliente);
        }

        public void EditarCliente(E_Cliente Cliente)
        {
            objCliente.EditarCliente(Cliente);
        }

        public void EliminarCliente(int id)
        {
            objCliente.EliminarCliente(id);
        }
    }
}
