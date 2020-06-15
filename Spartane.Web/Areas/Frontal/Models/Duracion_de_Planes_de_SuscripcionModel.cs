using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Duracion_de_Planes_de_SuscripcionModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_en_Meses { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_en_Dias { get; set; }

    }
	
	public class Duracion_de_Planes_de_Suscripcion_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_en_Meses { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_en_Dias { get; set; }

    }


}

