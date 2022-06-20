using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Ventas
    {
		private int _idventa;
		private string _codigo;
		private DateTime _fecha;
		private Decimal _total;
		private string _nombre;
		private int _idusuario;

		public int Idventa { get => _idventa; set => _idventa = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public Decimal Total { get => _total; set => _total = value; }
		public string Nombre_cliente { get => _nombre; set => _nombre = value;}
		public int Idusuario { get => _idusuario; set => _idusuario = value; }

	}
}
