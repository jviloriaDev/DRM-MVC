using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_Suscripcion_EspecialistasGridModel
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Costo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

