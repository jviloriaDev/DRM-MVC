using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Horarios_ActividadModel
    {
        [Required]
        public int Folio { get; set; }
        public bool Reservada { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Codigo_de_ReservacionCodigo_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public string Parentesco_con_el_EmpleadoDescripcion { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_ReservacionDescripcion { get; set; }
        public bool Asistio { get; set; }

    }
	
	public class Detalle_Horarios_Actividad_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public bool? Reservada { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Codigo_de_ReservacionCodigo_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public string Parentesco_con_el_EmpleadoDescripcion { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_ReservacionDescripcion { get; set; }
        public bool? Asistio { get; set; }

    }


}

