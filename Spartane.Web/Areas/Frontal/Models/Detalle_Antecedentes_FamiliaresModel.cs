using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Antecedentes_FamiliaresModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Enfermedad { get; set; }
        public string EnfermedadDescripcion { get; set; }
        public int? Parentesco { get; set; }
        public string ParentescoDescripcion { get; set; }

    }
	
	public class Detalle_Antecedentes_Familiares_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Enfermedad { get; set; }
        public string EnfermedadDescripcion { get; set; }
        public int? Parentesco { get; set; }
        public string ParentescoDescripcion { get; set; }

    }


}

