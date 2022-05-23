using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Pagos
    {
		private int _idpagos;
		private string _codigo;
		private DateTime _fecha; 
		private string _nombre;
		private Decimal _interes_mora;
		private Decimal _cuota;
		private Decimal _mora;
		private Decimal _total;
		private int _idcredito;
		private int _idcliente;


		public int IdPagos { get => _idpagos; set => _idpagos = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public Decimal Interes_Mora { get => _interes_mora; set => _interes_mora = value;}
		public Decimal Cuota { get => _cuota; set => _cuota = value; }
		public Decimal Mora { get => _mora; set => _mora = value; }
		public Decimal Total { get => _total; set => _total = value; }
		public int Idcredito { get => _idcredito; set => _idcredito = value; }
		public int Idcliente { get => _idcliente; set => _idcliente = value; }
	}
}
