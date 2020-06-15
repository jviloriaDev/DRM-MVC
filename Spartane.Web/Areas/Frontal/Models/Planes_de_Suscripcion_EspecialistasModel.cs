using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_Suscripcion_EspecialistasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }
        [Range(0, 9999999999)]
        public int? Costo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Planes_de_Suscripcion_Especialistas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }
        [Range(0, 9999999999)]
        public int? Costo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

