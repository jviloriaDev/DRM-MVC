using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Nivel_de_IntensidadModel
    {
        [Required]
        public int Folio { get; set; }
        public string Intensidad { get; set; }

    }
	
	public class Nivel_de_Intensidad_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Intensidad { get; set; }

    }


}

