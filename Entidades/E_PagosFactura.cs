using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_PagosFactura
    {

		private int _idpagof;
		private string _codigo;
		private DateTime _fecha;
		private string _nombre;
		private string _descripcion;
		private int _cuotas_pagadas;
		private int _cuotas_faltante;
		private Decimal _total;
		private int _idcliente;
		private int _idusuario;
		private string _usuario;

		public int IdPagoF { get => _idpagof; set => _idpagof = value; }
		public string Codigo { get => _codigo; set => _codigo = value; }
		public DateTime Fecha { get => _fecha; set => _fecha = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Descripcion { get => _descripcion; set => _descripcion = value; }
		public int CuotasPagadas { get => _cuotas_pagadas; set => _cuotas_pagadas = value; }
		public int CuotasFaltante { get => _cuotas_faltante; set => _cuotas_faltante = value; }
		public Decimal Total { get => _total; set => _total = value; }
		public int Idcliente { get => _idcliente; set => _idcliente = value; }
		public int IdUsuario { get => _idusuario; set => _idusuario = value; }
		public string Usuario { get => _usuario; set => _usuario = value; }


	}
}
