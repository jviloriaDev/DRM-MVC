using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ConsultasMainModel
    {
        public ConsultasModel ConsultasInfo { set; get; }
        public Detalle_Resultados_ConsultasGridModelPost Detalle_Resultados_ConsultasGridInfo { set; get; }

    }

    public class Detalle_Resultados_ConsultasGridModelPost
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public string Fecha_de_Consulta { get; set; }
        public int? Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Interpretacion { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }

        public bool Removed { set; get; }
    }



}

