using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Credito
    {
		private int _idcredito;
		private string _codigo;
		private DateTime _fecha;
		private Decimal _total_venta;
		private Decimal _interes;
		private int _tiempo;
		private int _cuotas_pagadas;
		private Decimal _cuota;
		private Decimal _total_pagado;
		private Decimal _total_pagar;
		private int _idventa;
		private int _idcliente;

		public int IdCredito { get => _idcredito; set => _idcredito = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public Decimal Total_Venta { get => _total_venta; set => _total_venta = value; }
		public Decimal Interes { get => _interes; set => _interes = value; }
		public int Tiempo { get => _tiempo; set => _tiempo = value; }
		public int CuotasPagadas { get => _cuotas_pagadas; set => _cuotas_pagadas = value; }
		public Decimal Cuota { get => _cuota; set => _cuota = value; }
		public Decimal Total_Pagado { get => _total_pagado; set => _total_pagado = value; }
		public Decimal Total_pagar { get => _total_pagar; set => _total_pagar = value; }
		public int Idventa { get => _idventa; set => _idventa = value; }
		public int Idcliente { get => _idcliente; set => _idcliente = value; }

	}
}
