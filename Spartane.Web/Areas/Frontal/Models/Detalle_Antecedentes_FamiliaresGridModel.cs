using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Antecedentes_FamiliaresGridModel
    {
        public int Folio { get; set; }
        public int? Enfermedad { get; set; }
        public string EnfermedadDescripcion { get; set; }
        public int? Parentesco { get; set; }
        public string ParentescoDescripcion { get; set; }
        
    }
}

