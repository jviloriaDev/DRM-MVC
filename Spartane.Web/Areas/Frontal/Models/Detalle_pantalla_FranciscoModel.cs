using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_pantalla_FranciscoModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Archivo { get; set; }
        public HttpPostedFileBase ArchivoFile { set; get; }
        public int ArchivoRemoveAttachment { set; get; }
        public string Campo { get; set; }

    }
	
	public class Detalle_pantalla_Francisco_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Archivo { get; set; }
        public HttpPostedFileBase ArchivoFile { set; get; }
        public int ArchivoRemoveAttachment { set; get; }
        public string Campo { get; set; }

    }


}

