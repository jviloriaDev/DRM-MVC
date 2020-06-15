using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Indicadores_LaboratorioGridModel
    {
        public int Folio { get; set; }
        public string Indicador { get; set; }
        public string Unidad_de_Medida { get; set; }
        public int? Limite_inferior { get; set; }
        public int? Limite_superior { get; set; }
        
    }
}

