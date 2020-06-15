using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Planes_de_Suscripcion_EspecialistasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_SuscripcionNombre { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_PagoNombre { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public HttpPostedFileBase ContratoFile { set; get; }
        public int ContratoRemoveAttachment { set; get; }
        public bool Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Planes_de_Suscripcion_Especialistas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_SuscripcionNombre { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_PagoNombre { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public HttpPostedFileBase ContratoFile { set; get; }
        public int ContratoRemoveAttachment { set; get; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

