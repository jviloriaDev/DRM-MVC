using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_Exclusion_Ingredientes_PacienteModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }

    }
	
	public class MS_Exclusion_Ingredientes_Paciente_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }

    }


}

