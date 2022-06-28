using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class N_PagosFactura
    {
        D_PagosFactura pagosFactura = new D_PagosFactura();
        E_PagosFactura e_PagosFactura = new E_PagosFactura();


        public void InsertarPagosFactura(E_PagosFactura e_PagosFactura)
        {
            pagosFactura.InsertarPagoFactura(e_PagosFactura);
        }

        public List<E_PagosFactura> ListaPagosFactura(string buscar)
        {
            return pagosFactura.ListaPagosFactura(buscar);
        }

        public void EliminarPagoFactura(int id)
        {
            pagosFactura.EliminarPagoFactura(id);
        }

    }
}
