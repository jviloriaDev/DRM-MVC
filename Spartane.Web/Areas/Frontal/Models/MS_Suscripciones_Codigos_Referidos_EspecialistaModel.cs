using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Suscripciones_Codigos_Referidos_EspecialistaModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_SuscripcionNombre_del_Plan { get; set; }

    }
	
	public class MS_Suscripciones_Codigos_Referidos_Especialista_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_SuscripcionNombre_del_Plan { get; set; }

    }


}

