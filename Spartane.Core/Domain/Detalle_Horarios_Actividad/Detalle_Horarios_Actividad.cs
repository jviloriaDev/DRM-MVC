using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Actividades_del_Evento;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;
using Spartane.Core.Domain.Parentescos_Empleados;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Horarios_Actividad
{
    /// <summary>
    /// Detalle_Horarios_Actividad table
    /// </summary>
    public class Detalle_Horarios_Actividad: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Actividades { get; set; }
        public bool? Reservada { get; set; }
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public int? Sexo { get; set; }
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public bool? Asistio { get; set; }

        [ForeignKey("Folio_Actividades")]
        public virtual Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento Folio_Actividades_Actividades_del_Evento { get; set; }
        [ForeignKey("Codigo_de_Reservacion")]
        public virtual Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento { get; set; }
        [ForeignKey("Parentesco_con_el_Empleado")]
        public virtual Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados Parentesco_con_el_Empleado_Parentescos_Empleados { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus_de_la_Reservacion")]
        public virtual Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad { get; set; }

    }
	
	public class Detalle_Horarios_Actividad_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Actividades { get; set; }
        public bool? Reservada { get; set; }
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public int? Sexo { get; set; }
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public bool? Asistio { get; set; }

		        [ForeignKey("Folio_Actividades")]
        public virtual Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento Folio_Actividades_Actividades_del_Evento { get; set; }
        [ForeignKey("Codigo_de_Reservacion")]
        public virtual Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento { get; set; }
        [ForeignKey("Parentesco_con_el_Empleado")]
        public virtual Spartane.Core.Domain.Parentescos_Empleados.Parentescos_Empleados Parentesco_con_el_Empleado_Parentescos_Empleados { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus_de_la_Reservacion")]
        public virtual Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad { get; set; }

    }


}

