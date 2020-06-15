using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EventosMainModel
    {
        public EventosModel EventosInfo { set; get; }
        public Detalle_Actividades_EventoGridModelPost Detalle_Actividades_EventoGridInfo { set; get; }

    }

    public class Detalle_Actividades_EventoGridModelPost
    {
        public int Folio { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public int? Especialidad { get; set; }
        public string Nombre_de_la_Actividad { get; set; }
        public string Descripcion { get; set; }
        public int? Quien_imparte { get; set; }
        public string Dia { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public bool? Tiene_receso { get; set; }
        public string Hora_inicio_receso { get; set; }
        public string Hora_fin_receso { get; set; }
        public int? Duracion_maxima_por_paciente_mins { get; set; }
        public bool? Cupo_limitado { get; set; }
        public int? Cupo_maximo { get; set; }
        public int? Ubicacion { get; set; }
        public int? Estatus_de_la_Actividad { get; set; }

        public bool Removed { set; get; }
    }



}

