using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Registro_de_Asistencia_TelefonicaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_llamada { get; set; }
        public string Hora_de_llamada { get; set; }
        public int? Usuario_que_llama { get; set; }
        public string Usuario_que_llamaName { get; set; }
        public string Dispositivo { get; set; }
        public int? Nombre_Paciente { get; set; }
        public string Nombre_PacienteNombre_Completo { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Numero_telefonico_del_Paciente { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Telefono_de_Asistencia_marcado { get; set; }
        public string Hora_inicio_de_la_Llamada { get; set; }
        public string Hora_fin_de_la_Llamada { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Duracion_minutos { get; set; }
        public int? Asunto_de_la_Llamada { get; set; }
        public string Asunto_de_la_LlamadaDescripcion { get; set; }
        public int? Atendio { get; set; }
        public string AtendioName { get; set; }
        public string Comentarios { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Registro_de_Asistencia_Telefonica_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_llamada { get; set; }
        public string Hora_de_llamada { get; set; }
        public int? Usuario_que_llama { get; set; }
        public string Usuario_que_llamaName { get; set; }
        public string Dispositivo { get; set; }
        public int? Nombre_Paciente { get; set; }
        public string Nombre_PacienteNombre_Completo { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Numero_telefonico_del_Paciente { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Telefono_de_Asistencia_marcado { get; set; }
        public string Hora_inicio_de_la_Llamada { get; set; }
        public string Hora_fin_de_la_Llamada { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Duracion_minutos { get; set; }
        public int? Asunto_de_la_Llamada { get; set; }
        public string Asunto_de_la_LlamadaDescripcion { get; set; }
        public int? Atendio { get; set; }
        public string AtendioName { get; set; }
        public string Comentarios { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

