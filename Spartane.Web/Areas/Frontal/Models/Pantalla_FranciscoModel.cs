using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Pantalla_FranciscoModel
    {
        [Required]
        public int Folio { get; set; }
        public string Campo { get; set; }

    }
	
	public class Pantalla_Francisco_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Campo { get; set; }

    }


}

