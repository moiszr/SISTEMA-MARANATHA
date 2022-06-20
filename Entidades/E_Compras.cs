using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Compras
    {
		private int _idcompra;
		private string _codigo;
		private DateTime _fecha;
		private Decimal _total;
		private int _idusuario;

		public int Idcompra { get => _idcompra; set => _idcompra = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public Decimal Total { get => _total; set => _total = value; }
		public int Idusuario { get => _idusuario; set => _idusuario = value; }
	}

}
