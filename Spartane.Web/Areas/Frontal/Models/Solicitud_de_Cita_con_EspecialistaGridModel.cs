using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Solicitud_de_Cita_con_EspecialistaGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_solicitud { get; set; }
        public string Hora_de_solicitud { get; set; }
        public int? Usuario_que_solicita { get; set; }
        public string Usuario_que_solicitaName { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Celular_del_Paciente { get; set; }
        public int? Especialista { get; set; }
        public string EspecialistaNombre_Completo { get; set; }
        public string Correo_del_Especialista { get; set; }
        public bool? Correo_enviado { get; set; }
        public string Fecha_de_Retroalimentacion { get; set; }
        public string Hora_de_Retroalimentacion { get; set; }
        public int? Asististe_a_tu_cita { get; set; }
        public string Asististe_a_tu_citaDescripcion { get; set; }
        public int? Calificacion_Especialista { get; set; }
        public string Calificacion_EspecialistaDescripcion { get; set; }
        public int? Motivo_no_concreto_cita { get; set; }
        public string Motivo_no_concreto_citaDescripcion { get; set; }
        
    }
}

