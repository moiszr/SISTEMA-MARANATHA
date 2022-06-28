using System;

namespace Entidades
{
    public class E_Credito
    {
        private int _idcredito;
        private string _codigo;
        private int _no_pago;
        private DateTime _fecha;
        private Decimal _capital;
        private Decimal _interes;
        private Decimal _cuotas;
        private Decimal _mora;

        private int _idPago;
        private string _estado;

        public int Idcredito { get => _idcredito; set => _idcredito = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public int No_Pago { get => _no_pago; set => _no_pago = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public decimal Capital { get => _capital; set => _capital = value; }
        public decimal Interes { get => _interes; set => _interes = value; }
        public decimal Cuotas { get => _cuotas; set => _cuotas = value; }
        public decimal Mora { get => _mora; set => _mora = value; }
        public int IdPago { get => _idPago; set => _idPago = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
