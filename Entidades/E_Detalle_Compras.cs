using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Detalle_Compras
    {
		private int _iddetallecompra;
		private string _codigo;
		private Decimal _preciocompra;
		private int _cantidad;
		private Decimal _subtotal;
		private int _idcompra;
		private int _idproducto;
		private string _productos;

		public int IDdetallecompra { get => _iddetallecompra; set => _iddetallecompra = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public Decimal Preciocompra { get => _preciocompra; set => _preciocompra = value; }
		public int Cantidad { get => _cantidad; set => _cantidad = value; }
		public Decimal Subtotal { get => _subtotal; set => _subtotal = value; }
		public int Idcompra { get => _idcompra; set => _idcompra = value; }
		public int Idproducto { get => _idproducto; set => _idproducto = value; }
		public string Producto { get => _productos; set => _productos = value; }

	}
}
