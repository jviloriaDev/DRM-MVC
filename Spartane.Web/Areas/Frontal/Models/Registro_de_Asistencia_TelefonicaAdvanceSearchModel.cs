using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Registro_de_Asistencia_TelefonicaAdvanceSearchModel
    {
        public Registro_de_Asistencia_TelefonicaAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_llamada { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_llamada", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_llamada { set; get; }

        public string ToHora_de_llamada { set; get; }
        public string FromHora_de_llamada { set; get; }

        public Filters Usuario_que_llamaFilter { set; get; }
        public string AdvanceUsuario_que_llama { set; get; }
        public int[] AdvanceUsuario_que_llamaMultiple { set; get; }

        public Filters DispositivoFilter { set; get; }
        public string Dispositivo { set; get; }

        public Filters Nombre_PacienteFilter { set; get; }
        public string AdvanceNombre_Paciente { set; get; }
        public int[] AdvanceNombre_PacienteMultiple { set; get; }

        public Filters SuscripcionFilter { set; get; }
        public string AdvanceSuscripcion { set; get; }
        public int[] AdvanceSuscripcionMultiple { set; get; }

        public Filters Numero_telefonico_del_PacienteFilter { set; get; }
        public string Numero_telefonico_del_Paciente { set; get; }

        public Filters Correo_del_PacienteFilter { set; get; }
        public string Correo_del_Paciente { set; get; }

        public Filters Telefono_de_Asistencia_marcadoFilter { set; get; }
        public string Telefono_de_Asistencia_marcado { set; get; }

        public string ToHora_inicio_de_la_Llamada { set; get; }
        public string FromHora_inicio_de_la_Llamada { set; get; }

        public string ToHora_fin_de_la_Llamada { set; get; }
        public string FromHora_fin_de_la_Llamada { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromDuracion_minutos { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromDuracion_minutos", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToDuracion_minutos { set; get; }

        public Filters Asunto_de_la_LlamadaFilter { set; get; }
        public string AdvanceAsunto_de_la_Llamada { set; get; }
        public int[] AdvanceAsunto_de_la_LlamadaMultiple { set; get; }

        public Filters AtendioFilter { set; get; }
        public string AdvanceAtendio { set; get; }
        public int[] AdvanceAtendioMultiple { set; get; }

        public Filters ComentariosFilter { set; get; }
        public string Comentarios { set; get; }

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }


    }
}
