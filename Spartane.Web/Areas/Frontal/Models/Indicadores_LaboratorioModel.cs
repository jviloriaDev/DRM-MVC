using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Indicadores_LaboratorioModel
    {
        [Required]
        public int Folio { get; set; }
        public string Indicador { get; set; }
        public string Unidad_de_Medida { get; set; }
        [Range(0, 9999999999)]
        public int? Limite_inferior { get; set; }
        [Range(0, 9999999999)]
        public int? Limite_superior { get; set; }

    }
	
	public class Indicadores_Laboratorio_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Indicador { get; set; }
        public string Unidad_de_Medida { get; set; }
        [Range(0, 9999999999)]
        public int? Limite_inferior { get; set; }
        [Range(0, 9999999999)]
        public int? Limite_superior { get; set; }

    }


}

