using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class CaloriasModel
    {
        [Required]
        public int Clave { get; set; }
        public string Cantidad { get; set; }

    }
	
	public class Calorias_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Cantidad { get; set; }

    }


}

