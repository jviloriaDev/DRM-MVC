using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Planes_AlimenticiosGridModel
    {
        public int Folio { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public string Tiempo_de_ComidaComida { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_DiaDia { get; set; }
        public string Fecha { get; set; }
        public int? Platillo { get; set; }
        public string PlatilloNombre_de_Platillo { get; set; }
        public bool? Modificado { get; set; }
        
    }
}

