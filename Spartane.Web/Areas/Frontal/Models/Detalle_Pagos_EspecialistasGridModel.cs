using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Pagos_EspecialistasGridModel
    {
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_SuscripcionNombre { get; set; }
        public string Concepto_de_Pago { get; set; }
        public string Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public string Forma_de_PagoNombre { get; set; }
        public string Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public string Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }
        
    }
}

