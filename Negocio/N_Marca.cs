using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class N_Marca
    {
        D_Marca objMarca = new D_Marca();

        public List<E_Marca> ListarMarca(string buscar)
        {
            return objMarca.ListaMarcas(buscar);
        }

        public void InsertarMarca(E_Marca Marca)
        {
            objMarca.InsertarMarca(Marca);
        }

        public void EditarMarca(E_Marca Marca)
        {
            objMarca.EditarMarca(Marca);
        }

        public void EliminarMarca(E_Marca Marca)
        {
            objMarca.EliminarMarca(Marca);
        }
    }
}
