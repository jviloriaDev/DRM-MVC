using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Caracteristicas_IngredienteModel
    {
        [Required]
        public int Folio { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

    }
	
	public class Detalle_Caracteristicas_Ingrediente_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

    }


}

