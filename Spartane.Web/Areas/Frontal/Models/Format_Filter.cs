using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Format_Filter
    {
        public string Nombre { get; set; }
        public string Nombre_de_Tabla { get; set; }
        public string Nombre_de_Campo { get; set; }
        public string Query_Condition { get; set; }
        public long Tipo_de_Campo { get; set; }
    }

}