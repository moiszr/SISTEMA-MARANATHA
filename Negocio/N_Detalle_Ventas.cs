using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class N_Detalle_Ventas
    {
        D_Detalle_Ventas objDato = new D_Detalle_Ventas();

        public List<E_Detalle_Ventas> ListarDetalle_Ventas(int id)
        {
            return objDato.ListaDetalle_Ventas(id);
        }
    }
}
