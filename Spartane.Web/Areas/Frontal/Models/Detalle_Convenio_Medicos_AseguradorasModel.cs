using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Convenio_Medicos_AseguradorasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Aseguradora_medico { get; set; }
        public string Aseguradora_medicoNombre { get; set; }

    }
	
	public class Detalle_Convenio_Medicos_Aseguradoras_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Aseguradora_medico { get; set; }
        public string Aseguradora_medicoNombre { get; set; }

    }


}

