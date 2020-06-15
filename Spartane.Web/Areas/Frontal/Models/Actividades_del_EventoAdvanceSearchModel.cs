using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Actividades_del_EventoAdvanceSearchModel
    {
        public Actividades_del_EventoAdvanceSearchModel()
        {
            Tiene_receso = RadioOptions.NoApply;
            Cupo_limitado = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Registro { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Registro", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Registro { set; get; }

        public string ToHora_de_Registro { set; get; }
        public string FromHora_de_Registro { set; get; }

        public Filters Usuario_que_RegistraFilter { set; get; }
        public string AdvanceUsuario_que_Registra { set; get; }
        public int[] AdvanceUsuario_que_RegistraMultiple { set; get; }

        public Filters EventoFilter { set; get; }
        public string AdvanceEvento { set; get; }
        public int[] AdvanceEventoMultiple { set; get; }

        public Filters ActividadFilter { set; get; }
        public string AdvanceActividad { set; get; }
        public int[] AdvanceActividadMultiple { set; get; }

        public Filters DescripcionFilter { set; get; }
        public string Descripcion { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromDia { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromDia", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToDia { set; get; }

        public string ToHora_inicio { set; get; }
        public string FromHora_inicio { set; get; }

        public string ToHora_fin { set; get; }
        public string FromHora_fin { set; get; }

        public RadioOptions Tiene_receso { set; get; }

        public string ToHora_inicio_receso { set; get; }
        public string FromHora_inicio_receso { set; get; }

        public string ToHora_fin_receso { set; get; }
        public string FromHora_fin_receso { set; get; }

        public Filters UbicacionFilter { set; get; }
        public string AdvanceUbicacion { set; get; }
        public int[] AdvanceUbicacionMultiple { set; get; }

        public Filters Tipo_de_ActividadFilter { set; get; }
        public string AdvanceTipo_de_Actividad { set; get; }
        public int[] AdvanceTipo_de_ActividadMultiple { set; get; }

        public Filters Quien_imparteFilter { set; get; }
        public string AdvanceQuien_imparte { set; get; }
        public int[] AdvanceQuien_imparteMultiple { set; get; }

        public Filters EspecialidadFilter { set; get; }
        public string AdvanceEspecialidad { set; get; }
        public int[] AdvanceEspecialidadMultiple { set; get; }

        public RadioOptions Cupo_limitado { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCupo_maximo { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCupo_maximo", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCupo_maximo { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromDuracion_maxima_por_Paciente_mins { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromDuracion_maxima_por_Paciente_mins", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToDuracion_maxima_por_Paciente_mins { set; get; }

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }


    }
}
