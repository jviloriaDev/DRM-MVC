using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Resultados_ConsultasGridModel
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public string Folio_PacientesNombre_Completo { get; set; }
        public string Fecha_de_Consulta { get; set; }
        public int? Indicador { get; set; }
        public string IndicadorNombre { get; set; }
        public int? Resultado { get; set; }
        public string Interpretacion { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        
    }
}

