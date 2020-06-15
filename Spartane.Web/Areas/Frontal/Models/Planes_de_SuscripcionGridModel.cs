using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_SuscripcionGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Beneficiario { get; set; }
        public string Tipo_de_BeneficiarioNombre { get; set; }
        public string Nombre { get; set; }
        public string Nombre_del_Plan { get; set; }
        public int? Duracion_en_meses { get; set; }
        public int? Duracion { get; set; }
        public int? Dietas_por_mes { get; set; }
        public int? Rutinas_por_mes { get; set; }
        public decimal? Costo_mensual { get; set; }
        public decimal? Precio_Final { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

