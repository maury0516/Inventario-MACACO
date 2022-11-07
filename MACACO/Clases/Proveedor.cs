using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MACACO.Clases
{
    public class Proveedor
    {
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public int estado { get; set; }
    }

}