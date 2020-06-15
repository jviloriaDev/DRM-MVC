using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Antecedentes_No_PatologicosGridModel
    {
        public int Folio { get; set; }
        public int? Sustancia { get; set; }
        public string SustanciaDescripcion { get; set; }
        public int? Frecuencia { get; set; }
        public string FrecuenciaDescripcion { get; set; }
        public int? Cantidad { get; set; }
        
    }
}

