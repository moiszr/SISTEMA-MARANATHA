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
		private decimal _precioventa;
		private int _cantidad;
		private decimal _descuento;
		private decimal _subtotal;
		private int _idventa;

		private int  _idproducto;
		private string _producto;
		private string _codigoProd;
		private int _idCategoria;
		private string _codigoVent;

		public int IDdetalleventa { get => _iddetalleventa; set => _iddetalleventa = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public decimal Preciocompra { get => _precioventa; set => _precioventa = value;}
		public int Cantidad { get => _cantidad; set => _cantidad = value; }
		public decimal Descuento { get => _descuento; set => _descuento = value; }
		public decimal Subtotal { get => _subtotal; set => _subtotal = value; }	
		public int Idventa { get => _idventa; set => _idventa = value; }
		
		public int Idproducto { get => _idproducto; set => _idproducto = value; }
		public string Producto { get => _producto; set => _producto = value; }
        public string CodigoProd { get => _codigoProd; set => _codigoProd = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string CodigoVent { get => _codigoVent; set => _codigoVent = value; }
    }
}
