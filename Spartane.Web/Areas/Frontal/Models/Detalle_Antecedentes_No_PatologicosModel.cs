using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Antecedentes_No_PatologicosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Sustancia { get; set; }
        public string SustanciaDescripcion { get; set; }
        public int? Frecuencia { get; set; }
        public string FrecuenciaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad { get; set; }

    }
	
	public class Detalle_Antecedentes_No_Patologicos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Sustancia { get; set; }
        public string SustanciaDescripcion { get; set; }
        public int? Frecuencia { get; set; }
        public string FrecuenciaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad { get; set; }

    }


}

