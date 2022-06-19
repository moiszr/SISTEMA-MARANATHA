using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Categoria
    {
        private int _idCategoria;
        private string _codigoCategoria;
        private string _nombreCategoria;
        private string _descripcionCategoria;
        private decimal _porciento_Venta;
        private decimal _porciento_Descuento;


        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string CodigoCategoria { get => _codigoCategoria; set => _codigoCategoria = value; }
        public string NombreCategoria { get => _nombreCategoria; set => _nombreCategoria = value; }
        public string DescripcionCategoria { get => _descripcionCategoria; set => _descripcionCategoria = value; }
        public decimal Porciento_Venta { get => _porciento_Venta; set => _porciento_Venta = value; }
        public decimal Porciento_Descuento { get => _porciento_Descuento; set => _porciento_Descuento = value; }


    }
}
