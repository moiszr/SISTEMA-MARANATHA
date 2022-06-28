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

        public List<E_Garante> ListarGarante(int id)
        {
            return objGarante.ListarGarante(id);
        }

        public int ObtenerID()
        {
            return objGarante.ObtenerID();
        }

        public void InsertarGarante (E_Garante garante)
        {
            objGarante.InsertarGarante(garante);
        }
    }
}
