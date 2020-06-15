using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_Registro;
using Spartane.Core.Domain.Tipo_Paciente;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estado_Civil;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Objetivos;
using Spartane.Core.Domain.Estatus_por_Suscripcion;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Tipo_de_Dieta;
using Spartane.Core.Domain.Suplementos;
using Spartane.Core.Domain.Preferencias_Sal;
using Spartane.Core.Domain.Preferencias_Grasas;
using Spartane.Core.Domain.Cantidad_Comidas;
using Spartane.Core.Domain.Preferencias_Preparacion;
using Spartane.Core.Domain.Preferencias_Entrecomidas;
using Spartane.Core.Domain.Nivel_de_Satisfaccion;
using Spartane.Core.Domain.Tipo_Modificacion_Alimentos;
using Spartane.Core.Domain.Periodo_del_dia;
using Spartane.Core.Domain.Estado_de_Animo;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Frecuencia_Ejercicio;
using Spartane.Core.Domain.Duracion_Ejercicio;
using Spartane.Core.Domain.Tipo_Ejercicio;
using Spartane.Core.Domain.Antiguedad_Ejercicios;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_corporal;
using Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Core.Domain.Interpretacion_Calorias;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Pacientes
{
    /// <summary>
    /// Pacientes table
    /// </summary>
    public class Pacientes: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Tipo_de_Registro { get; set; }
        public int? Tipo_de_Paciente { get; set; }
        public int? Usuario_Registrado { get; set; }
        public int? Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public string Nombre_del_Padre_o_Tutor { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Lugar_de_nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Estado_Civil { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Pais { get; set; }
        public int? Estado { get; set; }
        public string Ocupacion { get; set; }
        public int? Cantidad_hijos { get; set; }
        public int? Objetivo { get; set; }
        public int? Estatus_Paciente { get; set; }
        public int? Cuenta_con_padecimientos { get; set; }
        public int? Frecuencia_Cardiaca { get; set; }
        public int? Frecuencia_Respiratoria { get; set; }
        public int? Presion_sistolica { get; set; }
        public int? Presion_diastolica { get; set; }
        public decimal? Peso_actual { get; set; }
        public decimal? Estatura { get; set; }
        public decimal? Peso_habitual { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public int? Anchura_de_muneca_mm { get; set; }
        public int? Circunferencia_de_brazo_cm { get; set; }
        public int? Pliegue_cutaneo_tricipital_mm { get; set; }
        public int? Pliegue_cutaneo_bicipital_mm { get; set; }
        public int? Pliegue_cutaneo_subescapular_mm { get; set; }
        public int? Pliegue_cutaneo_supraespinal_mm { get; set; }
        public int? Edad_Metabolica { get; set; }
        public int? Agua_corporal { get; set; }
        public int? Grasa_Visceral { get; set; }
        public int? Grasa_Corporal { get; set; }
        public int? Grasa_Corporal_kg { get; set; }
        public int? Masa_Muscular_kg { get; set; }
        public int? Masa_Muscular_ { get; set; }
        public int? Esta_embarazada { get; set; }
        public int? Semana_de_gestacion { get; set; }
        public int? Peso_pregestacional { get; set; }
        public int? Toma_anticonceptivos { get; set; }
        public string Nombre_del_Anticonceptivo { get; set; }
        public string Dosis { get; set; }
        public int? Climaterio { get; set; }
        public DateTime? Fecha_Climaterio { get; set; }
        public int? Terapia_reemplazo_hormonal { get; set; }
        public int? Tipo_Dieta { get; set; }
        public int? Suplementos { get; set; }
        public int? Consumo_de_sal { get; set; }
        public int? Grasas_Preferencias { get; set; }
        public int? Comidas_cantidad { get; set; }
        public int? Preparacion_Preferencias { get; set; }
        public int? Entre_comidas { get; set; }
        public int? Apetito { get; set; }
        public int? Habitos_Modificacion { get; set; }
        public int? Horario_hambre { get; set; }
        public int? Cuando_cambia_mi_estado_de_animo { get; set; }
        public int? Medicamentos_bajar_peso { get; set; }
        public string Cual_medicamento { get; set; }
        public int? Frecuencia_Ejercicio { get; set; }
        public int? Duracion_Ejercicio { get; set; }
        public int? Tipo_Ejercicio { get; set; }
        public int? Antiguedad_Ejercicio { get; set; }
        public int? IMC { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string Complexion_corporal { get; set; }
        public int? Interpretacion_complexion_corporal { get; set; }
        public string Distribucion_de_grasa_corporal { get; set; }
        public int? Interpretacion_grasa_corporal { get; set; }
        public string Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Registro")]
        public virtual Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro Tipo_de_Registro_Tipo_de_Registro { get; set; }
        [ForeignKey("Tipo_de_Paciente")]
        public virtual Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente Tipo_de_Paciente_Tipo_Paciente { get; set; }
        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Lugar_de_nacimiento")]
        public virtual Spartane.Core.Domain.Estado.Estado Lugar_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estado_Civil")]
        public virtual Spartane.Core.Domain.Estado_Civil.Estado_Civil Estado_Civil_Estado_Civil { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Objetivo")]
        public virtual Spartane.Core.Domain.Objetivos.Objetivos Objetivo_Objetivos { get; set; }
        [ForeignKey("Estatus_Paciente")]
        public virtual Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion Estatus_Paciente_Estatus_por_Suscripcion { get; set; }
        [ForeignKey("Cuenta_con_padecimientos")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Cuenta_con_padecimientos_Respuesta_Logica { get; set; }
        [ForeignKey("Esta_embarazada")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Esta_embarazada_Respuesta_Logica { get; set; }
        [ForeignKey("Toma_anticonceptivos")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Toma_anticonceptivos_Respuesta_Logica { get; set; }
        [ForeignKey("Climaterio")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Climaterio_Respuesta_Logica { get; set; }
        [ForeignKey("Terapia_reemplazo_hormonal")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Terapia_reemplazo_hormonal_Respuesta_Logica { get; set; }
        [ForeignKey("Tipo_Dieta")]
        public virtual Spartane.Core.Domain.Tipo_de_Dieta.Tipo_de_Dieta Tipo_Dieta_Tipo_de_Dieta { get; set; }
        [ForeignKey("Suplementos")]
        public virtual Spartane.Core.Domain.Suplementos.Suplementos Suplementos_Suplementos { get; set; }
        [ForeignKey("Consumo_de_sal")]
        public virtual Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal Consumo_de_sal_Preferencias_Sal { get; set; }
        [ForeignKey("Grasas_Preferencias")]
        public virtual Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas Grasas_Preferencias_Preferencias_Grasas { get; set; }
        [ForeignKey("Comidas_cantidad")]
        public virtual Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas Comidas_cantidad_Cantidad_Comidas { get; set; }
        [ForeignKey("Preparacion_Preferencias")]
        public virtual Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion Preparacion_Preferencias_Preferencias_Preparacion { get; set; }
        [ForeignKey("Entre_comidas")]
        public virtual Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas Entre_comidas_Preferencias_Entrecomidas { get; set; }
        [ForeignKey("Apetito")]
        public virtual Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion Apetito_Nivel_de_Satisfaccion { get; set; }
        [ForeignKey("Habitos_Modificacion")]
        public virtual Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos Habitos_Modificacion_Tipo_Modificacion_Alimentos { get; set; }
        [ForeignKey("Horario_hambre")]
        public virtual Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia Horario_hambre_Periodo_del_dia { get; set; }
        [ForeignKey("Cuando_cambia_mi_estado_de_animo")]
        public virtual Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo Cuando_cambia_mi_estado_de_animo_Estado_de_Animo { get; set; }
        [ForeignKey("Medicamentos_bajar_peso")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Medicamentos_bajar_peso_Respuesta_Logica { get; set; }
        [ForeignKey("Frecuencia_Ejercicio")]
        public virtual Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio Frecuencia_Ejercicio_Frecuencia_Ejercicio { get; set; }
        [ForeignKey("Duracion_Ejercicio")]
        public virtual Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio Duracion_Ejercicio_Duracion_Ejercicio { get; set; }
        [ForeignKey("Tipo_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio Tipo_Ejercicio_Tipo_Ejercicio { get; set; }
        [ForeignKey("Antiguedad_Ejercicio")]
        public virtual Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios Antiguedad_Ejercicio_Antiguedad_Ejercicios { get; set; }
        [ForeignKey("Interpretacion_IMC")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC Interpretacion_IMC_Interpretacion_IMC { get; set; }
        [ForeignKey("IMC_Pediatria")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC IMC_Pediatria_Interpretacion_IMC { get; set; }
        [ForeignKey("Interpretacion_complexion_corporal")]
        public virtual Spartane.Core.Domain.Interpretacion_corporal.Interpretacion_corporal Interpretacion_complexion_corporal_Interpretacion_corporal { get; set; }
        [ForeignKey("Interpretacion_grasa_corporal")]
        public virtual Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal { get; set; }
        [ForeignKey("Interpretacion_indice")]
        public virtual Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera Interpretacion_indice_Interpretacion_indice_cintura__cadera { get; set; }
        [ForeignKey("Interpretacion_agua")]
        public virtual Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua Interpretacion_agua_Interpretacion_consumo_de_agua { get; set; }
        [ForeignKey("Interpretacion_frecuencia")]
        public virtual Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        [ForeignKey("Interpretacion_dificultad")]
        public virtual Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios { get; set; }
        [ForeignKey("Interpretacion_calorias")]
        public virtual Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias Interpretacion_calorias_Interpretacion_Calorias { get; set; }

    }
	
	public class Pacientes_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Tipo_de_Registro { get; set; }
        public int? Tipo_de_Paciente { get; set; }
        public int? Usuario_Registrado { get; set; }
        public int? Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public string Nombre_del_Padre_o_Tutor { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Lugar_de_nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Estado_Civil { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Pais { get; set; }
        public int? Estado { get; set; }
        public string Ocupacion { get; set; }
        public int? Cantidad_hijos { get; set; }
        public int? Objetivo { get; set; }
        public int? Estatus_Paciente { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Registro")]
        public virtual Spartane.Core.Domain.Tipo_de_Registro.Tipo_de_Registro Tipo_de_Registro_Tipo_de_Registro { get; set; }
        [ForeignKey("Tipo_de_Paciente")]
        public virtual Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente Tipo_de_Paciente_Tipo_Paciente { get; set; }
        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Lugar_de_nacimiento")]
        public virtual Spartane.Core.Domain.Estado.Estado Lugar_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estado_Civil")]
        public virtual Spartane.Core.Domain.Estado_Civil.Estado_Civil Estado_Civil_Estado_Civil { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Objetivo")]
        public virtual Spartane.Core.Domain.Objetivos.Objetivos Objetivo_Objetivos { get; set; }
        [ForeignKey("Estatus_Paciente")]
        public virtual Spartane.Core.Domain.Estatus_por_Suscripcion.Estatus_por_Suscripcion Estatus_Paciente_Estatus_por_Suscripcion { get; set; }

    }

	public class Pacientes_Padecimientos
    {
                public int Folio { get; set; }
        public int? Cuenta_con_padecimientos { get; set; }

		        [ForeignKey("Cuenta_con_padecimientos")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Cuenta_con_padecimientos_Respuesta_Logica { get; set; }

    }

	public class Pacientes_Antecedentes
    {
                public int Folio { get; set; }

		
    }

	public class Pacientes_Mediciones_Iniciales
    {
                public int Folio { get; set; }
        public int? Frecuencia_Cardiaca { get; set; }
        public int? Frecuencia_Respiratoria { get; set; }
        public int? Presion_sistolica { get; set; }
        public int? Presion_diastolica { get; set; }
        public decimal? Peso_actual { get; set; }
        public decimal? Estatura { get; set; }
        public decimal? Peso_habitual { get; set; }
        public int? Circunferencia_de_cintura_cm { get; set; }
        public int? Circunferencia_de_cadera_cm { get; set; }
        public int? Anchura_de_muneca_mm { get; set; }
        public int? Circunferencia_de_brazo_cm { get; set; }
        public int? Pliegue_cutaneo_tricipital_mm { get; set; }
        public int? Pliegue_cutaneo_bicipital_mm { get; set; }
        public int? Pliegue_cutaneo_subescapular_mm { get; set; }
        public int? Pliegue_cutaneo_supraespinal_mm { get; set; }
        public int? Edad_Metabolica { get; set; }
        public int? Agua_corporal { get; set; }
        public int? Grasa_Visceral { get; set; }
        public int? Grasa_Corporal { get; set; }
        public int? Grasa_Corporal_kg { get; set; }
        public int? Masa_Muscular_kg { get; set; }
        public int? Masa_Muscular_ { get; set; }

		
    }

	public class Pacientes_Datos_Ginecologicos
    {
                public int Folio { get; set; }
        public int? Esta_embarazada { get; set; }
        public int? Semana_de_gestacion { get; set; }
        public int? Peso_pregestacional { get; set; }
        public int? Toma_anticonceptivos { get; set; }
        public string Nombre_del_Anticonceptivo { get; set; }
        public string Dosis { get; set; }
        public int? Climaterio { get; set; }
        public DateTime? Fecha_Climaterio { get; set; }
        public int? Terapia_reemplazo_hormonal { get; set; }

		        [ForeignKey("Esta_embarazada")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Esta_embarazada_Respuesta_Logica { get; set; }
        [ForeignKey("Toma_anticonceptivos")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Toma_anticonceptivos_Respuesta_Logica { get; set; }
        [ForeignKey("Climaterio")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Climaterio_Respuesta_Logica { get; set; }
        [ForeignKey("Terapia_reemplazo_hormonal")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Terapia_reemplazo_hormonal_Respuesta_Logica { get; set; }

    }

	public class Pacientes_Historia_Nutricional
    {
                public int Folio { get; set; }
        public int? Tipo_Dieta { get; set; }
        public int? Suplementos { get; set; }
        public int? Consumo_de_sal { get; set; }
        public int? Grasas_Preferencias { get; set; }
        public int? Comidas_cantidad { get; set; }
        public int? Preparacion_Preferencias { get; set; }
        public int? Entre_comidas { get; set; }
        public int? Apetito { get; set; }
        public int? Habitos_Modificacion { get; set; }
        public int? Horario_hambre { get; set; }
        public int? Cuando_cambia_mi_estado_de_animo { get; set; }
        public int? Medicamentos_bajar_peso { get; set; }
        public string Cual_medicamento { get; set; }

		        [ForeignKey("Tipo_Dieta")]
        public virtual Spartane.Core.Domain.Tipo_de_Dieta.Tipo_de_Dieta Tipo_Dieta_Tipo_de_Dieta { get; set; }
        [ForeignKey("Suplementos")]
        public virtual Spartane.Core.Domain.Suplementos.Suplementos Suplementos_Suplementos { get; set; }
        [ForeignKey("Consumo_de_sal")]
        public virtual Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal Consumo_de_sal_Preferencias_Sal { get; set; }
        [ForeignKey("Grasas_Preferencias")]
        public virtual Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas Grasas_Preferencias_Preferencias_Grasas { get; set; }
        [ForeignKey("Comidas_cantidad")]
        public virtual Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas Comidas_cantidad_Cantidad_Comidas { get; set; }
        [ForeignKey("Preparacion_Preferencias")]
        public virtual Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion Preparacion_Preferencias_Preferencias_Preparacion { get; set; }
        [ForeignKey("Entre_comidas")]
        public virtual Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas Entre_comidas_Preferencias_Entrecomidas { get; set; }
        [ForeignKey("Apetito")]
        public virtual Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion Apetito_Nivel_de_Satisfaccion { get; set; }
        [ForeignKey("Habitos_Modificacion")]
        public virtual Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos Habitos_Modificacion_Tipo_Modificacion_Alimentos { get; set; }
        [ForeignKey("Horario_hambre")]
        public virtual Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia Horario_hambre_Periodo_del_dia { get; set; }
        [ForeignKey("Cuando_cambia_mi_estado_de_animo")]
        public virtual Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo Cuando_cambia_mi_estado_de_animo_Estado_de_Animo { get; set; }
        [ForeignKey("Medicamentos_bajar_peso")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Medicamentos_bajar_peso_Respuesta_Logica { get; set; }

    }

	public class Pacientes_Estilo_de_Vida
    {
                public int Folio { get; set; }
        public int? Frecuencia_Ejercicio { get; set; }
        public int? Duracion_Ejercicio { get; set; }
        public int? Tipo_Ejercicio { get; set; }
        public int? Antiguedad_Ejercicio { get; set; }

		        [ForeignKey("Frecuencia_Ejercicio")]
        public virtual Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio Frecuencia_Ejercicio_Frecuencia_Ejercicio { get; set; }
        [ForeignKey("Duracion_Ejercicio")]
        public virtual Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio Duracion_Ejercicio_Duracion_Ejercicio { get; set; }
        [ForeignKey("Tipo_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio Tipo_Ejercicio_Tipo_Ejercicio { get; set; }
        [ForeignKey("Antiguedad_Ejercicio")]
        public virtual Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios Antiguedad_Ejercicio_Antiguedad_Ejercicios { get; set; }

    }

	public class Pacientes_Resultados
    {
                public int Folio { get; set; }
        public int? IMC { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string Complexion_corporal { get; set; }
        public int? Interpretacion_complexion_corporal { get; set; }
        public string Distribucion_de_grasa_corporal { get; set; }
        public int? Interpretacion_grasa_corporal { get; set; }
        public string Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Observaciones { get; set; }

		        [ForeignKey("Interpretacion_IMC")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC Interpretacion_IMC_Interpretacion_IMC { get; set; }
        [ForeignKey("IMC_Pediatria")]
        public virtual Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC IMC_Pediatria_Interpretacion_IMC { get; set; }
        [ForeignKey("Interpretacion_complexion_corporal")]
        public virtual Spartane.Core.Domain.Interpretacion_corporal.Interpretacion_corporal Interpretacion_complexion_corporal_Interpretacion_corporal { get; set; }
        [ForeignKey("Interpretacion_grasa_corporal")]
        public virtual Spartane.Core.Domain.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal { get; set; }
        [ForeignKey("Interpretacion_indice")]
        public virtual Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera Interpretacion_indice_Interpretacion_indice_cintura__cadera { get; set; }
        [ForeignKey("Interpretacion_agua")]
        public virtual Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua Interpretacion_agua_Interpretacion_consumo_de_agua { get; set; }
        [ForeignKey("Interpretacion_frecuencia")]
        public virtual Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        [ForeignKey("Interpretacion_dificultad")]
        public virtual Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios { get; set; }
        [ForeignKey("Interpretacion_calorias")]
        public virtual Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias Interpretacion_calorias_Interpretacion_Calorias { get; set; }

    }

	public class Pacientes_Suscripcion
    {
                public int Folio { get; set; }

		
    }


}

