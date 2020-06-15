using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Registro_en_Actividad_EventoModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Actividad { get; set; }
        public string ActividadNombre_de_la_Actividad { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public bool Es_para_un_familiar { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco { get; set; }
        public string ParentescoDescripcion { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public string Fecha_de_nacimiento { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_ReservacionDescripcion { get; set; }
        public string Codigo_Reservacion { get; set; }

    }
	
	public class Detalle_Registro_en_Actividad_Evento_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Actividad { get; set; }
        public string ActividadNombre_de_la_Actividad { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public bool? Es_para_un_familiar { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco { get; set; }
        public string ParentescoDescripcion { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public string Fecha_de_nacimiento { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_ReservacionDescripcion { get; set; }
        public string Codigo_Reservacion { get; set; }

    }


}

