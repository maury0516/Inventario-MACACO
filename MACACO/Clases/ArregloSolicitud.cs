using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MACACO.Clases
{
    public class ArregloSolicitud
    {
        [Serializable()]
        public class gridV
        {
            public int id { get; set; }
            public string codigo { get; set; }
            public int cantidad { get; set; }
            public int op { get; set; }
        }
    }
}