using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Codigos_ReferidosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        [Range(0, 9999999999)]
        public int? Porcentaje_de_descuento { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_Referenciados { get; set; }
        public bool Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Codigos_Referidos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        [Range(0, 9999999999)]
        public int? Porcentaje_de_descuento { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_Referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

