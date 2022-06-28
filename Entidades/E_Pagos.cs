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
		private string _estado;

        private string _codigoventa;
        private string _cedula;
        private string _cliente;
        private string _garante;
		
		private int _idVenta;
		private int _idCliente;
		private int _idGarante;

        public int Idpagos { get => _idpagos; set => _idpagos = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Codigoventa { get => _codigoventa; set => _codigoventa = value; }
        public string Cedula { get => _cedula; set => _cedula = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public string Garante { get => _garante; set => _garante = value; }
        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public int IdGarante { get => _idGarante; set => _idGarante = value; }
    }
}
