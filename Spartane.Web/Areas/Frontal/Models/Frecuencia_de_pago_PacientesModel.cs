using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Frecuencia_de_pago_PacientesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }

    }
	
	public class Frecuencia_de_pago_Pacientes_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }

    }


}

