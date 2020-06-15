using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PacientesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Registro { get; set; }
        public string Tipo_de_RegistroDescripcion { get; set; }
        public int? Tipo_de_Paciente { get; set; }
        public string Tipo_de_PacienteDescripcion { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_RegistradoName { get; set; }
        public int? Empresa { get; set; }
        public string EmpresaNombre_de_la_Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Fecha_de_nacimiento { get; set; }
        public string Nombre_del_Padre_o_Tutor { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public string Pais_de_nacimientoNombre_del_Pais { get; set; }
        public int? Lugar_de_nacimiento { get; set; }
        public string Lugar_de_nacimientoNombre_del_Estado { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public int? Estado_Civil { get; set; }
        public string Estado_CivilDescripcion { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        [Range(0, 9999999999)]
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre_del_Estado { get; set; }
        public string Ocupacion { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_hijos { get; set; }
        public int? Objetivo { get; set; }
        public string ObjetivoDescripcion { get; set; }
        public int? Estatus_Paciente { get; set; }
        public string Estatus_PacienteDescripcion { get; set; }
        public int? Cuenta_con_padecimientos { get; set; }
        public string Cuenta_con_padecimientosDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_Cardiaca { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_Respiratoria { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_sistolica { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_diastolica { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_actual { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Estatura { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_habitual { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cintura_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cadera_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Anchura_de_muneca_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_brazo_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_tricipital_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_bicipital_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_subescapular_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_supraespinal_mm { get; set; }
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
        public int? Masa_Muscular_ { get; set; }
        public int? Esta_embarazada { get; set; }
        public string Esta_embarazadaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Semana_de_gestacion { get; set; }
        [Range(0, 9999999999)]
        public int? Peso_pregestacional { get; set; }
        public int? Toma_anticonceptivos { get; set; }
        public string Toma_anticonceptivosDescripcion { get; set; }
        public string Nombre_del_Anticonceptivo { get; set; }
        public string Dosis { get; set; }
        public int? Climaterio { get; set; }
        public string ClimaterioDescripcion { get; set; }
        public string Fecha_Climaterio { get; set; }
        public int? Terapia_reemplazo_hormonal { get; set; }
        public string Terapia_reemplazo_hormonalDescripcion { get; set; }
        public int? Tipo_Dieta { get; set; }
        public string Tipo_DietaDescripcion { get; set; }
        public int? Suplementos { get; set; }
        public string SuplementosDescripcion { get; set; }
        public int? Consumo_de_sal { get; set; }
        public string Consumo_de_salDescripcion { get; set; }
        public int? Grasas_Preferencias { get; set; }
        public string Grasas_PreferenciasDescripcion { get; set; }
        public int? Comidas_cantidad { get; set; }
        public string Comidas_cantidadDescripcion { get; set; }
        public int? Preparacion_Preferencias { get; set; }
        public string Preparacion_PreferenciasDescripcion { get; set; }
        public int? Entre_comidas { get; set; }
        public string Entre_comidasDescripcion { get; set; }
        public int? Apetito { get; set; }
        public string ApetitoDescripcion { get; set; }
        public int? Habitos_Modificacion { get; set; }
        public string Habitos_ModificacionDescripcion { get; set; }
        public int? Horario_hambre { get; set; }
        public string Horario_hambreDescripcion { get; set; }
        public int? Cuando_cambia_mi_estado_de_animo { get; set; }
        public string Cuando_cambia_mi_estado_de_animoDescripcion { get; set; }
        public int? Medicamentos_bajar_peso { get; set; }
        public string Medicamentos_bajar_pesoDescripcion { get; set; }
        public string Cual_medicamento { get; set; }
        public int? Frecuencia_Ejercicio { get; set; }
        public string Frecuencia_EjercicioDescripcion { get; set; }
        public int? Duracion_Ejercicio { get; set; }
        public string Duracion_EjercicioDescripcion { get; set; }
        public int? Tipo_Ejercicio { get; set; }
        public string Tipo_EjercicioDescripcion { get; set; }
        public int? Antiguedad_Ejercicio { get; set; }
        public string Antiguedad_EjercicioDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public string Interpretacion_IMCDescripcion { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string IMC_PediatriaDescripcion { get; set; }
        public string Complexion_corporal { get; set; }
        public int? Interpretacion_complexion_corporal { get; set; }
        public string Interpretacion_complexion_corporalDescripcion { get; set; }
        public string Distribucion_de_grasa_corporal { get; set; }
        public int? Interpretacion_grasa_corporal { get; set; }
        public string Interpretacion_grasa_corporalDescripcion { get; set; }
        public string Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Interpretacion_indiceDescripcion { get; set; }
        public string Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public string Interpretacion_aguaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Interpretacion_frecuenciaDescripcion { get; set; }
        public string Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public string Interpretacion_dificultadDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Interpretacion_caloriasDescripcion { get; set; }
        public string Observaciones { get; set; }

    }
	
	public class Pacientes_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Registro { get; set; }
        public string Tipo_de_RegistroDescripcion { get; set; }
        public int? Tipo_de_Paciente { get; set; }
        public string Tipo_de_PacienteDescripcion { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_RegistradoName { get; set; }
        public int? Empresa { get; set; }
        public string EmpresaNombre_de_la_Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Fecha_de_nacimiento { get; set; }
        public string Nombre_del_Padre_o_Tutor { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public string Pais_de_nacimientoNombre_del_Pais { get; set; }
        public int? Lugar_de_nacimiento { get; set; }
        public string Lugar_de_nacimientoNombre_del_Estado { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public int? Estado_Civil { get; set; }
        public string Estado_CivilDescripcion { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        [Range(0, 9999999999)]
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre_del_Estado { get; set; }
        public string Ocupacion { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad_hijos { get; set; }
        public int? Objetivo { get; set; }
        public string ObjetivoDescripcion { get; set; }
        public int? Estatus_Paciente { get; set; }
        public string Estatus_PacienteDescripcion { get; set; }

    }

	public class Pacientes_PadecimientosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Cuenta_con_padecimientos { get; set; }
        public string Cuenta_con_padecimientosDescripcion { get; set; }

    }

	public class Pacientes_AntecedentesModel
    {
        [Required]
        public int Folio { get; set; }

    }

	public class Pacientes_Mediciones_InicialesModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_Cardiaca { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_Respiratoria { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_sistolica { get; set; }
        [Range(0, 9999999999)]
        public int? Presion_diastolica { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_actual { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Estatura { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_habitual { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cintura_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_cadera_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Anchura_de_muneca_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Circunferencia_de_brazo_cm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_tricipital_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_bicipital_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_subescapular_mm { get; set; }
        [Range(0, 9999999999)]
        public int? Pliegue_cutaneo_supraespinal_mm { get; set; }
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
        public int? Masa_Muscular_ { get; set; }

    }

	public class Pacientes_Datos_GinecologicosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Esta_embarazada { get; set; }
        public string Esta_embarazadaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Semana_de_gestacion { get; set; }
        [Range(0, 9999999999)]
        public int? Peso_pregestacional { get; set; }
        public int? Toma_anticonceptivos { get; set; }
        public string Toma_anticonceptivosDescripcion { get; set; }
        public string Nombre_del_Anticonceptivo { get; set; }
        public string Dosis { get; set; }
        public int? Climaterio { get; set; }
        public string ClimaterioDescripcion { get; set; }
        public string Fecha_Climaterio { get; set; }
        public int? Terapia_reemplazo_hormonal { get; set; }
        public string Terapia_reemplazo_hormonalDescripcion { get; set; }

    }

	public class Pacientes_Historia_NutricionalModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_Dieta { get; set; }
        public string Tipo_DietaDescripcion { get; set; }
        public int? Suplementos { get; set; }
        public string SuplementosDescripcion { get; set; }
        public int? Consumo_de_sal { get; set; }
        public string Consumo_de_salDescripcion { get; set; }
        public int? Grasas_Preferencias { get; set; }
        public string Grasas_PreferenciasDescripcion { get; set; }
        public int? Comidas_cantidad { get; set; }
        public string Comidas_cantidadDescripcion { get; set; }
        public int? Preparacion_Preferencias { get; set; }
        public string Preparacion_PreferenciasDescripcion { get; set; }
        public int? Entre_comidas { get; set; }
        public string Entre_comidasDescripcion { get; set; }
        public int? Apetito { get; set; }
        public string ApetitoDescripcion { get; set; }
        public int? Habitos_Modificacion { get; set; }
        public string Habitos_ModificacionDescripcion { get; set; }
        public int? Horario_hambre { get; set; }
        public string Horario_hambreDescripcion { get; set; }
        public int? Cuando_cambia_mi_estado_de_animo { get; set; }
        public string Cuando_cambia_mi_estado_de_animoDescripcion { get; set; }
        public int? Medicamentos_bajar_peso { get; set; }
        public string Medicamentos_bajar_pesoDescripcion { get; set; }
        public string Cual_medicamento { get; set; }

    }

	public class Pacientes_Estilo_de_VidaModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Frecuencia_Ejercicio { get; set; }
        public string Frecuencia_EjercicioDescripcion { get; set; }
        public int? Duracion_Ejercicio { get; set; }
        public string Duracion_EjercicioDescripcion { get; set; }
        public int? Tipo_Ejercicio { get; set; }
        public string Tipo_EjercicioDescripcion { get; set; }
        public int? Antiguedad_Ejercicio { get; set; }
        public string Antiguedad_EjercicioDescripcion { get; set; }

    }

	public class Pacientes_ResultadosModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? IMC { get; set; }
        public int? Interpretacion_IMC { get; set; }
        public string Interpretacion_IMCDescripcion { get; set; }
        public int? IMC_Pediatria { get; set; }
        public string IMC_PediatriaDescripcion { get; set; }
        public string Complexion_corporal { get; set; }
        public int? Interpretacion_complexion_corporal { get; set; }
        public string Interpretacion_complexion_corporalDescripcion { get; set; }
        public string Distribucion_de_grasa_corporal { get; set; }
        public int? Interpretacion_grasa_corporal { get; set; }
        public string Interpretacion_grasa_corporalDescripcion { get; set; }
        public string Indice_cintura_cadera { get; set; }
        public int? Interpretacion_indice { get; set; }
        public string Interpretacion_indiceDescripcion { get; set; }
        public string Consumo_de_agua_resultado { get; set; }
        public int? Interpretacion_agua { get; set; }
        public string Interpretacion_aguaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Frecuencia_cardiaca_en_Esfuerzo { get; set; }
        public int? Interpretacion_frecuencia { get; set; }
        public string Interpretacion_frecuenciaDescripcion { get; set; }
        public string Dificultad_de_Rutina_de_Ejercicios { get; set; }
        public int? Interpretacion_dificultad { get; set; }
        public string Interpretacion_dificultadDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Calorias { get; set; }
        public int? Interpretacion_calorias { get; set; }
        public string Interpretacion_caloriasDescripcion { get; set; }
        public string Observaciones { get; set; }

    }

	public class Pacientes_SuscripcionModel
    {
        [Required]
        public int Folio { get; set; }

    }


}

