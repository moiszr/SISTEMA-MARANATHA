using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();

        public List<E_Categoria> ListarCategorias(string buscar)
        {
            return objDato.ListaCategorias(buscar);
        }

        public void InsertarCategoria(E_Categoria categoria)
        {
            objDato.InsertarCategoria(categoria);
        }

        public void EditarCategoria(E_Categoria categoria)
        {
            objDato.EditarCategoria(categoria);
        }

        public void EliminarCategoria(E_Categoria categoria)
        {
            objDato.EliminarCategoria(categoria);
        }

        public List<E_Categoria> BuscarCategoriasXID(int id)
        {
            return objDato.BuscarCategoriasXID(id);
        }
    }
}
