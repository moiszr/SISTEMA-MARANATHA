using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Garante
    {
		private int _idgarante;
		private string _codigo;
		private DateTime _fecha;
		private string _nombre;
		private string _apellido;
		private string _cedula;
		private string _telefono;
		private string _celular;
		private string _direccion;
		private string _trabajo;
		private string _sueldo;

		public int Idgarante { get => _idgarante; set => _idgarante = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Apellido { get => _apellido; set => _apellido = value; }
		public string Cedula { get => _cedula; set => _cedula = value; }
		public string Telefono { get => _telefono; set => _telefono = value; }
		public string Celular { get => _celular; set => _celular = value; }
		public string Direccion { get => _direccion; set => _direccion = value; }
		public string Trabajo { get => _trabajo; set => _trabajo = value; }
		public string Sueldo { get => _sueldo; set => _sueldo = value; }

	}
}
