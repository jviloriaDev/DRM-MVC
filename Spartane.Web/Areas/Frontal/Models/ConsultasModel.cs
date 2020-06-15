using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ConsultasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registo { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Fecha_Programada { get; set; }
        public int? Paciente { get; set; }
        public string PacienteNombre_Completo { get; set; }
        [Range(0, 9999999999)]
        public int? Edad { get; set; }
        public string Nombre_del_padre { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public string Email { get; set; }
        public int? Objetivo { get; set; }
        public string ObjetivoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_Cardiaca { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_sistolica { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_diastolica { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_actual { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Estatura { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cintura_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cadera_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Edad_Metabolica { get; set; }
        [Range(0, 9999999999)]
        public int? Agua_corporal { get; set; }
        [Range(0, 9999999999)]
        public int? Grasa_Visceral { get; set; }
        [Range(0, 9999999999)]
        public int? Grasa_Corporal { get; set; }
        [Range(0, 9999999999)]
        public int? Grasa_Corporal_kg { get; set; }
        [Range(0, 9999999999)]
        public int? Masa_Muscular_kg { get; set; }
        [Range(0, 9999999999)]
        public int? Semana_de_gestacion { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string IMC_PediatriaDescripcion { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public string Interpretacion_IMCDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public string Interpretacion_aguaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Interpretacion_frecuenciaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Interpretacion_indiceDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public string Interpretacion_dificultadDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Interpretacion_caloriasDescripcion { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_siguiente_Consulta { get; set; }

    }
	
	public class Consultas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registo { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Fecha_Programada { get; set; }
        public int? Paciente { get; set; }
        public string PacienteNombre_Completo { get; set; }
        [Range(0, 9999999999)]
        public int? Edad { get; set; }
        public string Nombre_del_padre { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public string Email { get; set; }
        public int? Objetivo { get; set; }
        public string ObjetivoDescripcion { get; set; }

    }

	public class Consultas_MedicionesModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_Cardiaca { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_sistolica { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_diastolica { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_actual { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Estatura { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cintura_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cadera_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Edad_Metabolica { get; set; }
        [Range(0, 9999999999)]
        public int? Agua_corporal { get; set; }
        [Range(0, 9999999999)]
        public int? Grasa_Visceral { get; set; }
        [Range(0, 9999999999)]
        public int? Grasa_Corporal { get; set; }
        [Range(0, 9999999999)]
        public int? Grasa_Corporal_kg { get; set; }
        [Range(0, 9999999999)]
        public int? Masa_Muscular_kg { get; set; }
        [Range(0, 9999999999)]
        public int? Semana_de_gestacion { get; set; }

    }

	public class Consultas_ResultadosModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string IMC_PediatriaDescripcion { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public string Interpretacion_IMCDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public string Interpretacion_aguaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Interpretacion_frecuenciaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Interpretacion_indiceDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public string Interpretacion_dificultadDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Interpretacion_caloriasDescripcion { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_siguiente_Consulta { get; set; }

    }


}

