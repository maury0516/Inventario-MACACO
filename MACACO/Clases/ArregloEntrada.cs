using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MACACO.Clases
{
    public class ArregloEntrada
    {
        [Serializable()]
        public class gridV
        {
            public int id { get; set; }
            public string codigo { get; set; }
            public int cantidad { get; set; }
            public int idArea { get; set; }
            public string area { get; set; }
            public double precio { get; set; }
        }
    }
}