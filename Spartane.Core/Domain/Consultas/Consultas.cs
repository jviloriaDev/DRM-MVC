using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Objetivos;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Core.Domain.Interpretacion_Calorias;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Consultas
{
    /// <summary>
    /// Consultas table
    /// </summary>
    public class Consultas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registo { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_Programada { get; set; }
        public int? Paciente { get; set; }
        public int? Edad { get; set; }
        public string Nombre_del_padre { get; set; }
        public int? Sexo { get; set; }
        public string Email { get; set; }
        public int? Objetivo { get; set; }
        public int? Frecuencia_Cardiaca { get; set; }
        public int? Presion_sistolica { get; set; }
        public int? Presion_diastolica { get; set; }
        public decimal? Peso_actual { get; set; }
        public decimal? Estatura { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public int? Edad_Metabolica { get; set; }
        public int? Agua_corporal { get; set; }
        public int? Grasa_Visceral { get; set; }
        public int? Grasa_Corporal { get; set; }
        public int? Grasa_Corporal_kg { get; set; }
        public int? Masa_Muscular_kg { get; set; }
        public int? Semana_de_gestacion { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public int? Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public int? Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public int? Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Observaciones { get; set; }
        public DateTime? Fecha_siguiente_Consulta { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Paciente_Pacientes { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Objetivo")]
        public virtual Spartane.Core.Domain.Objetivos.Objetivos Objetivo_Objetivos { get; set; }
        [ForeignKey("IMC_Pediatria")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC IMC_Pediatria_Interpretacion_IMC { get; set; }
        [ForeignKey("Interpretacion_IMC")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC Interpretacion_IMC_Interpretacion_IMC { get; set; }
        [ForeignKey("Interpretacion_agua")]
        public virtual Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua Interpretacion_agua_Interpretacion_consumo_de_agua { get; set; }
        [ForeignKey("Interpretacion_frecuencia")]
        public virtual Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        [ForeignKey("Interpretacion_indice")]
        public virtual Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera Interpretacion_indice_Interpretacion_indice_cintura__cadera { get; set; }
        [ForeignKey("Interpretacion_dificultad")]
        public virtual Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios { get; set; }
        [ForeignKey("Interpretacion_calorias")]
        public virtual Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias Interpretacion_calorias_Interpretacion_Calorias { get; set; }

    }
	
	public class Consultas_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registo { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_Programada { get; set; }
        public int? Paciente { get; set; }
        public int? Edad { get; set; }
        public string Nombre_del_padre { get; set; }
        public int? Sexo { get; set; }
        public string Email { get; set; }
        public int? Objetivo { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Paciente_Pacientes { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Objetivo")]
        public virtual Spartane.Core.Domain.Objetivos.Objetivos Objetivo_Objetivos { get; set; }

    }

	public class Consultas_Mediciones
    {
                public int Folio { get; set; }
        public int? Frecuencia_Cardiaca { get; set; }
        public int? Presion_sistolica { get; set; }
        public int? Presion_diastolica { get; set; }
        public decimal? Peso_actual { get; set; }
        public decimal? Estatura { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public int? Edad_Metabolica { get; set; }
        public int? Agua_corporal { get; set; }
        public int? Grasa_Visceral { get; set; }
        public int? Grasa_Corporal { get; set; }
        public int? Grasa_Corporal_kg { get; set; }
        public int? Masa_Muscular_kg { get; set; }
        public int? Semana_de_gestacion { get; set; }

		
    }

	public class Consultas_Resultados
    {
                public int Folio { get; set; }
        public int? IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public int? Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public int? Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public int? Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Observaciones { get; set; }
        public DateTime? Fecha_siguiente_Consulta { get; set; }

		        [ForeignKey("IMC_Pediatria")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC IMC_Pediatria_Interpretacion_IMC { get; set; }
        [ForeignKey("Interpretacion_IMC")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC Interpretacion_IMC_Interpretacion_IMC { get; set; }
        [ForeignKey("Interpretacion_agua")]
        public virtual Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua Interpretacion_agua_Interpretacion_consumo_de_agua { get; set; }
        [ForeignKey("Interpretacion_frecuencia")]
        public virtual Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        [ForeignKey("Interpretacion_indice")]
        public virtual Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera Interpretacion_indice_Interpretacion_indice_cintura__cadera { get; set; }
        [ForeignKey("Interpretacion_dificultad")]
        public virtual Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios { get; set; }
        [ForeignKey("Interpretacion_calorias")]
        public virtual Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias Interpretacion_calorias_Interpretacion_Calorias { get; set; }

    }


}

