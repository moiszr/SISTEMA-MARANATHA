using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Detalle_Ventas
    {

		private int _iddetalleventa;
		private string _codigo;
		private Decimal _precioventa;
		private int _cantidad;
		private Decimal _subtotal;
		private int _idventa;
		private int  _idproducto;
		private string _producto;
	

		public int IDdetalleventa { get => _iddetalleventa; set => _iddetalleventa = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public Decimal Preciocompra { get => _precioventa; set => _precioventa = value;}
		public int Cantidad { get => _cantidad; set => _cantidad = value; }
		public Decimal Subtotal { get => _subtotal; set => _subtotal = value; }	
		public int Idventa { get => _idventa; set => _idventa = value; }
		public int Idproducto { get => _idproducto; set => _idproducto = value; }
		public string Producto { get => _producto; set => _producto = value; }

	}
}
