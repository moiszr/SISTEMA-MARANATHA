using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class N_Ventas
    {
        D_Ventas objDato = new D_Ventas();

        public List<E_Ventas> ListarVentas(string buscar)
        {
            return objDato.ListaVenta(buscar);
        }

        public void InsertarVentas(E_Ventas ventas)
        {
            objDato.InsertarVentas(ventas);

        }
    }
}
