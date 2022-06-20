using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class N_Compras
    {
        D_Compras objDato = new D_Compras();

        public List<E_Compras> ListarCompras(string buscar)
        {
            return objDato.ListaCompra(buscar);
        }

        public void InsertarCompras(E_Compras Compras, List<E_Detalle_Compras> e_Detalle_Compras)
        {
            objDato.InsertarCompra(Compras, e_Detalle_Compras);

        }
    }
}
