using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class N_Pagos
    {
        D_Pagos objPagos = new D_Pagos();

        public List<E_Pagos> ListaPagos (string pagos)
        {
            return objPagos.ListaPagos(pagos);
        }

        public void InsertarPagos (E_Pagos pagos)
        {
            objPagos.InsertarPagos(pagos);
        }
        public void EditarPagos (E_Pagos pagos)
        {
            objPagos.EditarPagos(pagos);
        }
        public void EliminarPagos (E_Pagos pagos)
        {
            objPagos.EliminarPagos(pagos);
        }
    }
}
