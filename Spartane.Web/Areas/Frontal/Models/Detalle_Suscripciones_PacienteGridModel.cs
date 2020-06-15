using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Suscripciones_PacienteGridModel
    {
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_PagoNombre { get; set; }
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

