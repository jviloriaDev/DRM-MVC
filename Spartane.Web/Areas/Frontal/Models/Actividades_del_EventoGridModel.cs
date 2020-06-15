using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Actividades_del_EventoGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Evento { get; set; }
        public string EventoNombre_del_Evento { get; set; }
        public int? Actividad { get; set; }
        public string ActividadNombre_de_la_Actividad { get; set; }
        public string Descripcion { get; set; }
        public string Dia { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public bool? Tiene_receso { get; set; }
        public string Hora_inicio_receso { get; set; }
        public string Hora_fin_receso { get; set; }
        public int? Ubicacion { get; set; }
        public string UbicacionNombre { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public string Tipo_de_ActividadDescripcion { get; set; }
        public int? Quien_imparte { get; set; }
        public string Quien_imparteName { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public bool? Cupo_limitado { get; set; }
        public int? Cupo_maximo { get; set; }
        public int? Duracion_maxima_por_Paciente_mins { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

