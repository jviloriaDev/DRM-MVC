using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Planes_de_RutinasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_DiaDia { get; set; }
        public string Fecha { get; set; }
        public bool Realizado { get; set; }

    }
	
	public class Detalle_Planes_de_Rutinas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_DiaDia { get; set; }
        public string Fecha { get; set; }
        public bool? Realizado { get; set; }

    }


}

