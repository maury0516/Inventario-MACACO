using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MACACO.Clases
{
    public class SubCategorias
    {
        public int id_subcategoria { get; set; }
        public int id_categoria { get; set; }
        public string catname { get; set; }
        public string nombre { get; set; }
        public string calibre { get; set; }
        public int estado { get; set; }

        public static implicit operator SubCategorias(Catecoria v)
        {
            throw new NotImplementedException();
        }
    }
}