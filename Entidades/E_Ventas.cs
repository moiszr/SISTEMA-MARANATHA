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
		private string _nombre;
		private string usuario;
		private DateTime _fecha;
		private Decimal _total;
		private int _idusuario;
		private int? _idgarante;

        public int Idventa { get => _idventa; set => _idventa = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre_cliente { get => _nombre; set => _nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public decimal Total { get => _total; set => _total = value; }
        public int Idusuario { get => _idusuario; set => _idusuario = value; }
        public int? Idgarante { get => _idgarante; set => _idgarante = value; }
    }
}
