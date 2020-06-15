using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Suscripciones_EmpresaModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_de_Beneficiarios { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_PagoNombre { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Suscripciones_Empresa_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_de_Beneficiarios { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public string Frecuencia_de_PagoNombre { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

