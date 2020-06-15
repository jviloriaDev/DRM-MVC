using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Contratos_EmpresaGridModel
    {
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public int? Tipo_de_Contrato { get; set; }
        public string Tipo_de_ContratoDescripcion { get; set; }
        public int? Documento { get; set; }
        public Grid_File DocumentoFileInfo { set; get; }
        public string Fecha_de_Firma_de_Contrato { get; set; }
        
    }
}

