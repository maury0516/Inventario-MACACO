using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MACACO.Clases
{
    public class Articulo
    {
        public int id_articulo { get; set; }
        public int id_categoria { get; set; }
        public int id_subcategoria { get; set; }
        public string codigoarticulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public int id_medida { get; set; }
        public int id_marca { get; set; }
        public int id_area { get; set; }
        public int estado { get; set; }
        public string catname { get; set; }
        public string medida { get; set; }
        public string subcategoria { get; set; }
        public string marca { get; set; }
        public string area { get; set; }
    }
}