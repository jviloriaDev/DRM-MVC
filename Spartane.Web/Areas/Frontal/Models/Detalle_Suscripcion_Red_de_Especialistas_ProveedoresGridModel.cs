using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel
    {
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_SuscripcionDescripcion { get; set; }
        public string Fecha_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public Grid_File ContratoFileInfo { set; get; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

