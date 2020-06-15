using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Resultados_IMCModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        public string Estatus { get; set; }

    }
	
	public class Resultados_IMC_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        public string Estatus { get; set; }

    }


}

