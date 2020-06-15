using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_PadecimientosModel
    {
        [Required]
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
	
	public class Detalle_de_Padecimientos_Datos_GeneralesModel
    {
        [Required]
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

