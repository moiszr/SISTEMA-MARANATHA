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
		private int _idempleados;
		private int _idproveedores;

		public int Idcompra { get => _idcompra; set => _idcompra = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public Decimal Total { get => _total; set => _total = value; }
		public int Idempleados { get => _idempleados; set => _idempleados = value; }
		public int Idproveedores { get => _idproveedores; set => _idproveedores = value; }
	}

}
