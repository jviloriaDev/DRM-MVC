using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Examenes_LaboratorioModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Indicador { get; set; }
        public string IndicadorIndicador { get; set; }
        [Range(0, 9999999999)]
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_Referencia { get; set; }
        public string Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

    }
	
	public class Detalle_Examenes_Laboratorio_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Indicador { get; set; }
        public string IndicadorIndicador { get; set; }
        [Range(0, 9999999999)]
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_Referencia { get; set; }
        public string Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

    }


}

