using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tiempos_de_ComidaModel
    {
        [Required]
        public int Clave { get; set; }
        public string Comida { get; set; }
        public string Hora_min { get; set; }
        public string Hora_max { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }

    }
	
	public class Tiempos_de_Comida_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Comida { get; set; }
        public string Hora_min { get; set; }
        public string Hora_max { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }

    }


}

