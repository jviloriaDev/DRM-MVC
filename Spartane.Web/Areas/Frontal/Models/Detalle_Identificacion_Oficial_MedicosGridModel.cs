using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Identificacion_Oficial_MedicosGridModel
    {
        public int Folio { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public string Tipo_de_Identificacion_OficialDescripcion { get; set; }
        public int? Documento { get; set; }
        public Grid_File DocumentoFileInfo { set; get; }
        
    }
}

