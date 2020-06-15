using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Redes_Sociales_EspecialistaModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Red_Social { get; set; }
        public string Red_SocialDescripcion { get; set; }
        public string URL { get; set; }
        public bool Principal { get; set; }

    }
	
	public class Detalle_Redes_Sociales_Especialista_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Red_Social { get; set; }
        public string Red_SocialDescripcion { get; set; }
        public string URL { get; set; }
        public bool? Principal { get; set; }

    }


}

