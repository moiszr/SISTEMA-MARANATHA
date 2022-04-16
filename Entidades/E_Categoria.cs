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

        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string CodigoCategoria { get => _codigoCategoria; set => _codigoCategoria = value; }
        public string NombreCategoria { get => _nombreCategoria; set => _nombreCategoria = value; }
        public string DescripcionCategoria { get => _descripcionCategoria; set => _descripcionCategoria = value; }
    }
}
