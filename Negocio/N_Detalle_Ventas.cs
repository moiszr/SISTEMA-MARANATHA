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

        public List<E_Detalle_Ventas> ListarDetalle_Ventas(string buscar)
        {
            return objDato.ListaDetalle_Ventas(buscar);
        }

        public void InsertarDetalle_Ventas(E_Detalle_Ventas Detalle_Ventas)
        {
            objDato.InsertarDetalle_Ventas(Detalle_Ventas);

        }
    }
}
