using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Preferencia_BebidasGridModel
    {
        public int Folio { get; set; }
        public int? Bebida { get; set; }
        public string BebidaDescripcion { get; set; }
        public int? Cantidad { get; set; }
        public string CantidadDescripcion { get; set; }
        
    }
}

