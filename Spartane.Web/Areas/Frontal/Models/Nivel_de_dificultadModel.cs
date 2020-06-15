using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Nivel_de_dificultadModel
    {
        [Required]
        public int Folio { get; set; }
        public string Dificultad { get; set; }

    }
	
	public class Nivel_de_dificultad_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Dificultad { get; set; }

    }


}

