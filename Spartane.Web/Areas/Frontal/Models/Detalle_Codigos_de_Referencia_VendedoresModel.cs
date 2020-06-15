using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Codigos_de_Referencia_VendedoresModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Porcentaje_de_descuento { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_referenciados { get; set; }
        public bool Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Codigos_de_Referencia_Vendedores_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Porcentaje_de_descuento { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autorizaName { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

