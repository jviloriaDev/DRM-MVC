using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Especialistas_PacientesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Especialista { get; set; }
        public string EspecialistaName { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public string Fecha_inicio { get; set; }
        public string Fecha_fin { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_consultas { get; set; }
        public bool Principal { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Especialistas_Pacientes_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Especialista { get; set; }
        public string EspecialistaName { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public string Fecha_inicio { get; set; }
        public string Fecha_fin { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_consultas { get; set; }
        public bool? Principal { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

