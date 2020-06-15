using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Redes_Sociales_EspecialistaGridModel
    {
        public int Folio { get; set; }
        public int? Red_Social { get; set; }
        public string Red_SocialDescripcion { get; set; }
        public string URL { get; set; }
        public bool? Principal { get; set; }
        
    }
}

