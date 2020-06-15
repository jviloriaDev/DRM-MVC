using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Cantidad_fraccion_platillosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Cantidad { get; set; }

    }
	
	public class Cantidad_fraccion_platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Cantidad { get; set; }

    }


}

