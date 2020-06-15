using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PaisModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_del_Pais { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }

    }
	
	public class Pais_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_del_Pais { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }

    }


}

