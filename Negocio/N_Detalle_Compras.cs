using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class N_Detalle_Compras
    {
        D_Detalle_Compras objDato = new D_Detalle_Compras();

        public List<E_Detalle_Compras> ListarDetalle_Compras(int id)
        {
            return objDato.ListaDetalle_Compras(id);
        }
    }
}