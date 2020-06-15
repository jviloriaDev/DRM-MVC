using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Indicadores_ConsultasModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }

    }
	
	public class Indicadores_Consultas_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }

    }


}

