using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public class DataUser
    {
        static public  int idusuario;
        static public string usuario;
        static public string rol;
        static public string nombre;
        static public string apellido;


        static public List<E_Detalle_Ventas> eproductos = new List<E_Detalle_Ventas>();

    }
}
