using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Pagos_EmpresaModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Concepto_de_Pago { get; set; }
        public string Fecha_de_Suscripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_de_Pago { get; set; }
        [Range(0, 9999999999)]
        public int? De_Total_de_Pagos { get; set; }
        public string Fecha_Limite_de_Pago { get; set; }
        [Range(0, 9999999999)]
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public string Forma_de_PagoNombre { get; set; }
        public string Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Pagos_Empresa_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Concepto_de_Pago { get; set; }
        public string Fecha_de_Suscripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_de_Pago { get; set; }
        [Range(0, 9999999999)]
        public int? De_Total_de_Pagos { get; set; }
        public string Fecha_Limite_de_Pago { get; set; }
        [Range(0, 9999999999)]
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public string Forma_de_PagoNombre { get; set; }
        public string Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

