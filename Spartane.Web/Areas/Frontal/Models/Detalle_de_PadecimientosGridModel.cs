using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_PadecimientosGridModel
    {
        public int Folio { get; set; }
        public int? Padecimiento { get; set; }
        public string PadecimientoDescripcion { get; set; }
        public int? Tiempo_con_el_diagnostico { get; set; }
        public string Tiempo_con_el_diagnosticoDescripcion { get; set; }
        public int? Intervencion_quirurgica { get; set; }
        public string Intervencion_quirurgicaDescripcion { get; set; }
        public string Tratamiento { get; set; }
        public int? Estado_actual { get; set; }
        public string Estado_actualDescripcion { get; set; }
        
    }
}

