using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Productos
    {
        private int _idProductos;
        private string _codigoProducto;
        private string _producto;
        private decimal _precioCompra;
        private decimal _precioVenta;
        private int _stock;
        private int _idcategoria;
        private int _idmarca;
        private string buscar;
        private string totalCategoria;
        private string totalmarca;
        private string totalProductos;
        private string totalStock;

        public int IdProductos { get => _idProductos; set => _idProductos = value; }
        public string CodigoProducto { get => _codigoProducto; set => _codigoProducto = value; }
        public string Producto { get => _producto; set => _producto = value; }
        public decimal PrecioCompra { get => _precioCompra; set => _precioCompra = value; }
        public decimal PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public int Idmarca { get => _idmarca; set => _idmarca = value; }
        public string Buscar { get => buscar; set => buscar = value; }
        public string TotalCategoria { get => totalCategoria; set => totalCategoria = value; }
        public string Totalmarca { get => totalmarca; set => totalmarca = value; }
        public string TotalProductos { get => totalProductos; set => totalProductos = value; }
        public string TotalStock { get => totalStock; set => totalStock = value; }
    }
}
