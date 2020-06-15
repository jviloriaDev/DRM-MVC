using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Calificacion;
using Spartane.Core.Domain.Motivos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista
{
    /// <summary>
    /// Solicitud_de_Cita_con_Especialista table
    /// </summary>
    public class Solicitud_de_Cita_con_Especialista: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_solicitud { get; set; }
        public string Hora_de_solicitud { get; set; }
        public int? Usuario_que_solicita { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Celular_del_Paciente { get; set; }
        public int? Especialista { get; set; }
        public string Correo_del_Especialista { get; set; }
        public bool? Correo_enviado { get; set; }
        public DateTime? Fecha_de_Retroalimentacion { get; set; }
        public string Hora_de_Retroalimentacion { get; set; }
        public int? Asististe_a_tu_cita { get; set; }
        public int? Calificacion_Especialista { get; set; }
        public int? Motivo_no_concreto_cita { get; set; }

        [ForeignKey("Usuario_que_solicita")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_solicita_Spartan_User { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Especialista_Medicos { get; set; }
        [ForeignKey("Asististe_a_tu_cita")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Asististe_a_tu_cita_Respuesta_Logica { get; set; }
        [ForeignKey("Calificacion_Especialista")]
        public virtual Spartane.Core.Domain.Calificacion.Calificacion Calificacion_Especialista_Calificacion { get; set; }
        [ForeignKey("Motivo_no_concreto_cita")]
        public virtual Spartane.Core.Domain.Motivos.Motivos Motivo_no_concreto_cita_Motivos { get; set; }

    }
	
	public class Solicitud_de_Cita_con_Especialista_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_solicitud { get; set; }
        public string Hora_de_solicitud { get; set; }
        public int? Usuario_que_solicita { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Celular_del_Paciente { get; set; }
        public int? Especialista { get; set; }
        public string Correo_del_Especialista { get; set; }
        public bool? Correo_enviado { get; set; }

		        [ForeignKey("Usuario_que_solicita")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_solicita_Spartan_User { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Especialista_Medicos { get; set; }

    }

	public class Solicitud_de_Cita_con_Especialista_Solicitud
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Retroalimentacion { get; set; }
        public string Hora_de_Retroalimentacion { get; set; }
        public int? Asististe_a_tu_cita { get; set; }
        public int? Calificacion_Especialista { get; set; }
        public int? Motivo_no_concreto_cita { get; set; }

		        [ForeignKey("Asististe_a_tu_cita")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Asististe_a_tu_cita_Respuesta_Logica { get; set; }
        [ForeignKey("Calificacion_Especialista")]
        public virtual Spartane.Core.Domain.Calificacion.Calificacion Calificacion_Especialista_Calificacion { get; set; }
        [ForeignKey("Motivo_no_concreto_cita")]
        public virtual Spartane.Core.Domain.Motivos.Motivos Motivo_no_concreto_cita_Motivos { get; set; }

    }


}

