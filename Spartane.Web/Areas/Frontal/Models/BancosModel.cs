using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class BancosModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Completo { get; set; }
        public string Codigo { get; set; }

    }
	
	public class Bancos_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Completo { get; set; }
        public string Codigo { get; set; }

    }


}

