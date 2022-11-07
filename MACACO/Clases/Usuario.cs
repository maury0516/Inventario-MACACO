using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MACACO.Clases
{
    public class Usuario
    {
            public int id_usuario { get; set; }
            public int id_rol { get; set; }
            public string username { get; set; }
            public string nombre { get; set; }
            public string clave { get; set; }
            public int estado { get; set; }
            public string correo { get; set; }

    }
}