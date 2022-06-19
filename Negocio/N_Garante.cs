using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class N_Garante
    {
        D_Garante objGarante = new D_Garante();

        public List<E_Garante> ListaGarante (string garante)
        {
            return objGarante.ListaGarante(garante);
        }

        public void InsertarGarante (E_Garante garante)
        {
            objGarante.InsertarGarante(garante);
        }

        public void EditarGarante (E_Garante garante)
        {
            objGarante.EditarGarante(garante);
        }

        public void EliminarGarante(E_Garante garante)
        {
            objGarante.EliminarGarante(garante);
        }
    }
}
