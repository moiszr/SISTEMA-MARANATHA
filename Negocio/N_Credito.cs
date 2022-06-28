using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class N_Credito
    {
        D_Credito objCredito = new D_Credito();

        public List<E_Credito> ListarCredito(int id)
        {
            return objCredito.ListarCredito(id);
        }

        public void InsertarCredito(E_Credito credito)
        {
            objCredito.InsertarCredito(credito);
        }

        //public void EditarCredito(E_Credito credito)
        //{
        //    objCredito.EditarCredito(credito);
        //}
        //public void EliminarCredito(E_Credito credito)
        //{
        //    objCredito.EliminarCredito(credito);
        //}

    }
}
