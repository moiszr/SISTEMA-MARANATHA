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
    public class N_Productos
    {
        D_Productos datos = new D_Productos();
        E_Productos entidades = new E_Productos();

        public DataTable ListandoProductos()
        {
            return datos.ListarProductos();
        }

        public DataTable BuscandoProductos(string buscar)
        {
            entidades.Buscar = buscar;
            return datos.BuscarProductos(entidades);
        }

        public void InsertandoProductos(E_Productos productos)
        {
            datos.InsertarProductos(productos);
        }

        public void EditandoProdcutos(E_Productos productos)
        {
            datos.EditarProductos(productos);
        }

        public void EliminandoProducto(int id)
        {
            datos.EliminarProducto(id);
        }

        public void SumandoTotales(E_Productos productos)
        {
            datos.MostrarTotal(productos);
        }

        public List<E_Productos> ListarProductos()
        {
            return datos.ListarProductoCB();
        }


    }
}
