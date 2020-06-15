using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Identificacion_Oficial_MedicosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public string Tipo_de_Identificacion_OficialDescripcion { get; set; }
        public int? Documento { get; set; }
        public HttpPostedFileBase DocumentoFile { set; get; }
        public int DocumentoRemoveAttachment { set; get; }

    }
	
	public class Detalle_Identificacion_Oficial_Medicos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public string Tipo_de_Identificacion_OficialDescripcion { get; set; }
        public int? Documento { get; set; }
        public HttpPostedFileBase DocumentoFile { set; get; }
        public int DocumentoRemoveAttachment { set; get; }

    }


}

