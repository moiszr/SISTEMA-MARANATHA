using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuario
    {
        private int _idusuario; 
        private string _usuario;  
        private string _contraseña; 
        private int _idrol;
        private string _nombre;
        private string _apellido;

        public int Idusuario { get => _idusuario; set => _idusuario = value; }  
        public string Usario { get => _usuario;  set => _usuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public int Idrol { get => _idrol; set => _idrol = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }


    }
}
