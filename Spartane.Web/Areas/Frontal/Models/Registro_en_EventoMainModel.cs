using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Registro_en_EventoMainModel
    {
        public Registro_en_EventoModel Registro_en_EventoInfo { set; get; }
        public Detalle_Consulta_Actividades_Registro_EventoGridModelPost Detalle_Consulta_Actividades_Registro_EventoGridInfo { set; get; }
        public Detalle_Registro_en_Actividad_EventoGridModelPost Detalle_Registro_en_Actividad_EventoGridInfo { set; get; }

    }

    public class Detalle_Consulta_Actividades_Registro_EventoGridModelPost
    {
        public int Folio { get; set; }
        public int? Actividad { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public int? Especialidad { get; set; }
        public int? Imparte { get; set; }
        public string Fecha { get; set; }
        public int? Lugares_disponibles { get; set; }
        public string Horarios_disponibles { get; set; }
        public string Ubicacion { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Registro_en_Actividad_EventoGridModelPost
    {
        public int Folio { get; set; }
        public int? Actividad { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public bool? Es_para_un_familiar { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco { get; set; }
        public int? Sexo { get; set; }
        public string Fecha_de_nacimiento { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Codigo_Reservacion { get; set; }

        public bool Removed { set; get; }
    }



}

