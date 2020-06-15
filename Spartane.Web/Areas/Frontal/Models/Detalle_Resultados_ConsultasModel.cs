using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Resultados_ConsultasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public string Folio_PacientesNombre_Completo { get; set; }
        public string Fecha_de_Consulta { get; set; }
        public int? Indicador { get; set; }
        public string IndicadorNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Resultado { get; set; }
        public string Interpretacion { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        [Range(0, 9999999999)]
        public int? IMC_Pediatria { get; set; }

    }
	
	public class Detalle_Resultados_Consultas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public string Folio_PacientesNombre_Completo { get; set; }
        public string Fecha_de_Consulta { get; set; }
        public int? Indicador { get; set; }
        public string IndicadorNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Resultado { get; set; }
        public string Interpretacion { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        [Range(0, 9999999999)]
        public int? IMC_Pediatria { get; set; }

    }


}

