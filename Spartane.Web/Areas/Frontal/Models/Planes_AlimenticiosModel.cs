using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_AlimenticiosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Fecha_inicio_del_Plan { get; set; }
        public string Fecha_fin_del_Plan { get; set; }
        [Range(0, 9999999999)]
        public int? Semana { get; set; }
        public int? Paciente { get; set; }
        public string PacienteNombre_Completo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Planes_Alimenticios_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Fecha_inicio_del_Plan { get; set; }
        public string Fecha_fin_del_Plan { get; set; }
        [Range(0, 9999999999)]
        public int? Semana { get; set; }
        public int? Paciente { get; set; }
        public string PacienteNombre_Completo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

