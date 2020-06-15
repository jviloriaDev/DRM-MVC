using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Unidades_de_MedidaModel
    {
        [Required]
        public int Clave { get; set; }
        public string Unidad { get; set; }
        public string Abreviacion { get; set; }
        public string Texto_Singular { get; set; }
        public string Texto_Plural { get; set; }

    }
	
	public class Unidades_de_Medida_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Unidad { get; set; }
        public string Abreviacion { get; set; }
        public string Texto_Singular { get; set; }
        public string Texto_Plural { get; set; }

    }


}

