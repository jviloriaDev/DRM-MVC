using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel
    {
        public Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel()
        {
            Correo_enviado = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_solicitud { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_solicitud", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_solicitud { set; get; }

        public string ToHora_de_solicitud { set; get; }
        public string FromHora_de_solicitud { set; get; }

        public Filters Usuario_que_solicitaFilter { set; get; }
        public string AdvanceUsuario_que_solicita { set; get; }
        public int[] AdvanceUsuario_que_solicitaMultiple { set; get; }

        public Filters Nombre_CompletoFilter { set; get; }
        public string Nombre_Completo { set; get; }

        public Filters Correo_del_PacienteFilter { set; get; }
        public string Correo_del_Paciente { set; get; }

        public Filters Celular_del_PacienteFilter { set; get; }
        public string Celular_del_Paciente { set; get; }

        public Filters EspecialistaFilter { set; get; }
        public string AdvanceEspecialista { set; get; }
        public int[] AdvanceEspecialistaMultiple { set; get; }

        public Filters Correo_del_EspecialistaFilter { set; get; }
        public string Correo_del_Especialista { set; get; }

        public RadioOptions Correo_enviado { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Retroalimentacion { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Retroalimentacion", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Retroalimentacion { set; get; }

        public string ToHora_de_Retroalimentacion { set; get; }
        public string FromHora_de_Retroalimentacion { set; get; }

        public Filters Asististe_a_tu_citaFilter { set; get; }
        public string AdvanceAsististe_a_tu_cita { set; get; }
        public int[] AdvanceAsististe_a_tu_citaMultiple { set; get; }

        public Filters Calificacion_EspecialistaFilter { set; get; }
        public string AdvanceCalificacion_Especialista { set; get; }
        public int[] AdvanceCalificacion_EspecialistaMultiple { set; get; }

        public Filters Motivo_no_concreto_citaFilter { set; get; }
        public string AdvanceMotivo_no_concreto_cita { set; get; }
        public int[] AdvanceMotivo_no_concreto_citaMultiple { set; get; }


    }
}
