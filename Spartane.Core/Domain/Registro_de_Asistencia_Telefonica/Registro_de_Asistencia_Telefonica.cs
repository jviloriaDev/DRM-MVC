using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Asuntos_Asistencia_Telefonica;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus_Llamadas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Registro_de_Asistencia_Telefonica
{
    /// <summary>
    /// Registro_de_Asistencia_Telefonica table
    /// </summary>
    public class Registro_de_Asistencia_Telefonica: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_llamada { get; set; }
        public string Hora_de_llamada { get; set; }
        public int? Usuario_que_llama { get; set; }
        public string Dispositivo { get; set; }
        public int? Nombre_Paciente { get; set; }
        public int? Suscripcion { get; set; }
        public string Numero_telefonico_del_Paciente { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Telefono_de_Asistencia_marcado { get; set; }
        public string Hora_inicio_de_la_Llamada { get; set; }
        public string Hora_fin_de_la_Llamada { get; set; }
        public decimal? Duracion_minutos { get; set; }
        public int? Asunto_de_la_Llamada { get; set; }
        public int? Atendio { get; set; }
        public string Comentarios { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_llama")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_llama_Spartan_User { get; set; }
        [ForeignKey("Nombre_Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Nombre_Paciente_Pacientes { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Asunto_de_la_Llamada")]
        public virtual Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica { get; set; }
        [ForeignKey("Atendio")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Atendio_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas Estatus_Estatus_Llamadas { get; set; }

    }
	
	public class Registro_de_Asistencia_Telefonica_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_llamada { get; set; }
        public string Hora_de_llamada { get; set; }
        public int? Usuario_que_llama { get; set; }
        public string Dispositivo { get; set; }
        public int? Nombre_Paciente { get; set; }
        public int? Suscripcion { get; set; }
        public string Numero_telefonico_del_Paciente { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Telefono_de_Asistencia_marcado { get; set; }
        public string Hora_inicio_de_la_Llamada { get; set; }
        public string Hora_fin_de_la_Llamada { get; set; }
        public decimal? Duracion_minutos { get; set; }
        public int? Asunto_de_la_Llamada { get; set; }
        public int? Atendio { get; set; }
        public string Comentarios { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_llama")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_llama_Spartan_User { get; set; }
        [ForeignKey("Nombre_Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Nombre_Paciente_Pacientes { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Asunto_de_la_Llamada")]
        public virtual Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica { get; set; }
        [ForeignKey("Atendio")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Atendio_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas Estatus_Estatus_Llamadas { get; set; }

    }


}

