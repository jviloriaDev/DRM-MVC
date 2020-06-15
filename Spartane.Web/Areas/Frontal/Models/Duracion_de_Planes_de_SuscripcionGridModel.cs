using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Duracion_de_Planes_de_SuscripcionGridModel
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Cantidad_en_Meses { get; set; }
        public int? Cantidad_en_Dias { get; set; }
        
    }
}

