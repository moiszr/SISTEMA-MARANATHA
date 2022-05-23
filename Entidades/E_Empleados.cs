using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Empleados
    {
        private int _idempleado;
        private string _nombre; 
        private string _apellido;
        private string _cedula;
        private string _telefono;
        private string _direcion; 



        public int Idempleado { get => _idempleado; set => _idempleado = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Cedula { get => _cedula; set => _cedula = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Direccion { get => _direcion; set => _direcion = value; }


    }
}
