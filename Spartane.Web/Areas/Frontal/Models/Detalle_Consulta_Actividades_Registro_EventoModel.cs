using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Consulta_Actividades_Registro_EventoModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Actividad { get; set; }
        public string ActividadNombre_de_la_Actividad { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public string Tipo_de_ActividadDescripcion { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public int? Imparte { get; set; }
        public string ImparteName { get; set; }
        public string Fecha { get; set; }
        [Range(0, 9999999999)]
        public int? Lugares_disponibles { get; set; }
        public string Horarios_disponibles { get; set; }
        public string Ubicacion { get; set; }

    }
	
	public class Detalle_Consulta_Actividades_Registro_Evento_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Actividad { get; set; }
        public string ActividadNombre_de_la_Actividad { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public string Tipo_de_ActividadDescripcion { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public int? Imparte { get; set; }
        public string ImparteName { get; set; }
        public string Fecha { get; set; }
        [Range(0, 9999999999)]
        public int? Lugares_disponibles { get; set; }
        public string Horarios_disponibles { get; set; }
        public string Ubicacion { get; set; }

    }


}

