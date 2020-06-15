using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class RutinasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_la_Rutina { get; set; }
        public string Descripcion { get; set; }
        public string Equipamento { get; set; }
        public string Equipamento_alterno { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultadDificultad { get; set; }
        public int? Intensidad { get; set; }
        public string IntensidadIntensidad { get; set; }
        [Range(0, 9999999999)]
        public int? Duracion_aproximada_minutos { get; set; }
        public int? Genero { get; set; }
        public string GeneroDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Rutinas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_la_Rutina { get; set; }
        public string Descripcion { get; set; }
        public string Equipamento { get; set; }
        public string Equipamento_alterno { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultadDificultad { get; set; }
        public int? Intensidad { get; set; }
        public string IntensidadIntensidad { get; set; }
        [Range(0, 9999999999)]
        public int? Duracion_aproximada_minutos { get; set; }
        public int? Genero { get; set; }
        public string GeneroDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

