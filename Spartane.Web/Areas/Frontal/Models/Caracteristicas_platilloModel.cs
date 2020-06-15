using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Caracteristicas_platilloModel
    {
        [Required]
        public int Folio { get; set; }
        public string Caracteristicas { get; set; }

    }
	
	public class Caracteristicas_platillo_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Caracteristicas { get; set; }

    }


}

