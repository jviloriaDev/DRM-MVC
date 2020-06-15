using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Examenes_LaboratorioGridModel
    {
        public int Folio { get; set; }
        public int? Indicador { get; set; }
        public string IndicadorIndicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_Referencia { get; set; }
        public string Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }
        
    }
}

