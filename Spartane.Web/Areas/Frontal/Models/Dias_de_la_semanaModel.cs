using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dias_de_la_semanaModel
    {
        [Required]
        public int Clave { get; set; }
        public string Texto { get; set; }
        public string Dia { get; set; }

    }
	
	public class Dias_de_la_semana_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Texto { get; set; }
        public string Dia { get; set; }

    }


}

