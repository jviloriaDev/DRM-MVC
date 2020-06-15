using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PacientesAdvanceSearchModel
    {
        public PacientesAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Registro { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Registro", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Registro { set; get; }

        public string ToHora_de_Registro { set; get; }
        public string FromHora_de_Registro { set; get; }

        public Filters Usuario_que_RegistraFilter { set; get; }
        public string AdvanceUsuario_que_Registra { set; get; }
        public int[] AdvanceUsuario_que_RegistraMultiple { set; get; }

        public Filters Tipo_de_RegistroFilter { set; get; }
        public string AdvanceTipo_de_Registro { set; get; }
        public int[] AdvanceTipo_de_RegistroMultiple { set; get; }

        public Filters Tipo_de_PacienteFilter { set; get; }
        public string AdvanceTipo_de_Paciente { set; get; }
        public int[] AdvanceTipo_de_PacienteMultiple { set; get; }

        public Filters Usuario_RegistradoFilter { set; get; }
        public string AdvanceUsuario_Registrado { set; get; }
        public int[] AdvanceUsuario_RegistradoMultiple { set; get; }

        public Filters EmpresaFilter { set; get; }
        public string AdvanceEmpresa { set; get; }
        public int[] AdvanceEmpresaMultiple { set; get; }

        public Filters Numero_de_EmpleadoFilter { set; get; }
        public string Numero_de_Empleado { set; get; }

        public Filters NombresFilter { set; get; }
        public string Nombres { set; get; }

        public Filters Apellido_PaternoFilter { set; get; }
        public string Apellido_Paterno { set; get; }

        public Filters Apellido_MaternoFilter { set; get; }
        public string Apellido_Materno { set; get; }

        public Filters Nombre_CompletoFilter { set; get; }
        public string Nombre_Completo { set; get; }

        public Filters CelularFilter { set; get; }
        public string Celular { set; get; }

        public Filters EmailFilter { set; get; }
        public string Email { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_nacimiento { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_nacimiento", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_nacimiento { set; get; }

        public Filters Nombre_del_Padre_o_TutorFilter { set; get; }
        public string Nombre_del_Padre_o_Tutor { set; get; }

        public Filters Pais_de_nacimientoFilter { set; get; }
        public string AdvancePais_de_nacimiento { set; get; }
        public int[] AdvancePais_de_nacimientoMultiple { set; get; }

        public Filters Lugar_de_nacimientoFilter { set; get; }
        public string AdvanceLugar_de_nacimiento { set; get; }
        public int[] AdvanceLugar_de_nacimientoMultiple { set; get; }

        public Filters SexoFilter { set; get; }
        public string AdvanceSexo { set; get; }
        public int[] AdvanceSexoMultiple { set; get; }

        public Filters Estado_CivilFilter { set; get; }
        public string AdvanceEstado_Civil { set; get; }
        public int[] AdvanceEstado_CivilMultiple { set; get; }

        public Filters CalleFilter { set; get; }
        public string Calle { set; get; }

        public Filters Numero_exteriorFilter { set; get; }
        public string Numero_exterior { set; get; }

        public Filters Numero_interiorFilter { set; get; }
        public string Numero_interior { set; get; }

        public Filters ColoniaFilter { set; get; }
        public string Colonia { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCP { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCP", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCP { set; get; }

        public Filters CiudadFilter { set; get; }
        public string Ciudad { set; get; }

        public Filters PaisFilter { set; get; }
        public string AdvancePais { set; get; }
        public int[] AdvancePaisMultiple { set; get; }

        public Filters EstadoFilter { set; get; }
        public string AdvanceEstado { set; get; }
        public int[] AdvanceEstadoMultiple { set; get; }

        public Filters OcupacionFilter { set; get; }
        public string Ocupacion { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCantidad_hijos { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCantidad_hijos", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCantidad_hijos { set; get; }

        public Filters ObjetivoFilter { set; get; }
        public string AdvanceObjetivo { set; get; }
        public int[] AdvanceObjetivoMultiple { set; get; }

        public Filters Estatus_PacienteFilter { set; get; }
        public string AdvanceEstatus_Paciente { set; get; }
        public int[] AdvanceEstatus_PacienteMultiple { set; get; }

        public Filters Cuenta_con_padecimientosFilter { set; get; }
        public string AdvanceCuenta_con_padecimientos { set; get; }
        public int[] AdvanceCuenta_con_padecimientosMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFrecuencia_Cardiaca { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFrecuencia_Cardiaca", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFrecuencia_Cardiaca { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFrecuencia_Respiratoria { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFrecuencia_Respiratoria", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFrecuencia_Respiratoria { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPresion_sistolica { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPresion_sistolica", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPresion_sistolica { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPresion_diastolica { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPresion_diastolica", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPresion_diastolica { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPeso_actual { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPeso_actual", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPeso_actual { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromEstatura { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromEstatura", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToEstatura { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPeso_habitual { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPeso_habitual", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPeso_habitual { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCircunferencia_de_cintura_cm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCircunferencia_de_cintura_cm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCircunferencia_de_cintura_cm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCircunferencia_de_cadera_cm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCircunferencia_de_cadera_cm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCircunferencia_de_cadera_cm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromAnchura_de_muneca_mm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromAnchura_de_muneca_mm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToAnchura_de_muneca_mm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCircunferencia_de_brazo_cm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCircunferencia_de_brazo_cm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCircunferencia_de_brazo_cm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPliegue_cutaneo_tricipital_mm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPliegue_cutaneo_tricipital_mm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPliegue_cutaneo_tricipital_mm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPliegue_cutaneo_bicipital_mm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPliegue_cutaneo_bicipital_mm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPliegue_cutaneo_bicipital_mm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPliegue_cutaneo_subescapular_mm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPliegue_cutaneo_subescapular_mm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPliegue_cutaneo_subescapular_mm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPliegue_cutaneo_supraespinal_mm { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPliegue_cutaneo_supraespinal_mm", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPliegue_cutaneo_supraespinal_mm { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromEdad_Metabolica { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromEdad_Metabolica", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToEdad_Metabolica { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromAgua_corporal { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromAgua_corporal", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToAgua_corporal { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromGrasa_Visceral { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromGrasa_Visceral", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToGrasa_Visceral { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromGrasa_Corporal { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromGrasa_Corporal", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToGrasa_Corporal { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromGrasa_Corporal_kg { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromGrasa_Corporal_kg", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToGrasa_Corporal_kg { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromMasa_Muscular_kg { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromMasa_Muscular_kg", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToMasa_Muscular_kg { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromMasa_Muscular_ { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromMasa_Muscular_", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToMasa_Muscular_ { set; get; }

        public Filters Esta_embarazadaFilter { set; get; }
        public string AdvanceEsta_embarazada { set; get; }
        public int[] AdvanceEsta_embarazadaMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromSemana_de_gestacion { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromSemana_de_gestacion", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToSemana_de_gestacion { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPeso_pregestacional { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPeso_pregestacional", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPeso_pregestacional { set; get; }

        public Filters Toma_anticonceptivosFilter { set; get; }
        public string AdvanceToma_anticonceptivos { set; get; }
        public int[] AdvanceToma_anticonceptivosMultiple { set; get; }

        public Filters Nombre_del_AnticonceptivoFilter { set; get; }
        public string Nombre_del_Anticonceptivo { set; get; }

        public Filters DosisFilter { set; get; }
        public string Dosis { set; get; }

        public Filters ClimaterioFilter { set; get; }
        public string AdvanceClimaterio { set; get; }
        public int[] AdvanceClimaterioMultiple { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_Climaterio { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_Climaterio", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_Climaterio { set; get; }

        public Filters Terapia_reemplazo_hormonalFilter { set; get; }
        public string AdvanceTerapia_reemplazo_hormonal { set; get; }
        public int[] AdvanceTerapia_reemplazo_hormonalMultiple { set; get; }

        public Filters Tipo_DietaFilter { set; get; }
        public string AdvanceTipo_Dieta { set; get; }
        public int[] AdvanceTipo_DietaMultiple { set; get; }

        public Filters SuplementosFilter { set; get; }
        public string AdvanceSuplementos { set; get; }
        public int[] AdvanceSuplementosMultiple { set; get; }

        public Filters Consumo_de_salFilter { set; get; }
        public string AdvanceConsumo_de_sal { set; get; }
        public int[] AdvanceConsumo_de_salMultiple { set; get; }

        public Filters Grasas_PreferenciasFilter { set; get; }
        public string AdvanceGrasas_Preferencias { set; get; }
        public int[] AdvanceGrasas_PreferenciasMultiple { set; get; }

        public Filters Comidas_cantidadFilter { set; get; }
        public string AdvanceComidas_cantidad { set; get; }
        public int[] AdvanceComidas_cantidadMultiple { set; get; }

        public Filters Preparacion_PreferenciasFilter { set; get; }
        public string AdvancePreparacion_Preferencias { set; get; }
        public int[] AdvancePreparacion_PreferenciasMultiple { set; get; }

        public Filters Entre_comidasFilter { set; get; }
        public string AdvanceEntre_comidas { set; get; }
        public int[] AdvanceEntre_comidasMultiple { set; get; }

        public Filters ApetitoFilter { set; get; }
        public string AdvanceApetito { set; get; }
        public int[] AdvanceApetitoMultiple { set; get; }

        public Filters Habitos_ModificacionFilter { set; get; }
        public string AdvanceHabitos_Modificacion { set; get; }
        public int[] AdvanceHabitos_ModificacionMultiple { set; get; }

        public Filters Horario_hambreFilter { set; get; }
        public string AdvanceHorario_hambre { set; get; }
        public int[] AdvanceHorario_hambreMultiple { set; get; }

        public Filters Cuando_cambia_mi_estado_de_animoFilter { set; get; }
        public string AdvanceCuando_cambia_mi_estado_de_animo { set; get; }
        public int[] AdvanceCuando_cambia_mi_estado_de_animoMultiple { set; get; }

        public Filters Medicamentos_bajar_pesoFilter { set; get; }
        public string AdvanceMedicamentos_bajar_peso { set; get; }
        public int[] AdvanceMedicamentos_bajar_pesoMultiple { set; get; }

        public Filters Cual_medicamentoFilter { set; get; }
        public string Cual_medicamento { set; get; }

        public Filters Frecuencia_EjercicioFilter { set; get; }
        public string AdvanceFrecuencia_Ejercicio { set; get; }
        public int[] AdvanceFrecuencia_EjercicioMultiple { set; get; }

        public Filters Duracion_EjercicioFilter { set; get; }
        public string AdvanceDuracion_Ejercicio { set; get; }
        public int[] AdvanceDuracion_EjercicioMultiple { set; get; }

        public Filters Tipo_EjercicioFilter { set; get; }
        public string AdvanceTipo_Ejercicio { set; get; }
        public int[] AdvanceTipo_EjercicioMultiple { set; get; }

        public Filters Antiguedad_EjercicioFilter { set; get; }
        public string AdvanceAntiguedad_Ejercicio { set; get; }
        public int[] AdvanceAntiguedad_EjercicioMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromIMC { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromIMC", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToIMC { set; get; }

        public Filters Interpretacion_IMCFilter { set; get; }
        public string AdvanceInterpretacion_IMC { set; get; }
        public int[] AdvanceInterpretacion_IMCMultiple { set; get; }

        public Filters IMC_PediatriaFilter { set; get; }
        public string AdvanceIMC_Pediatria { set; get; }
        public int[] AdvanceIMC_PediatriaMultiple { set; get; }

        public Filters Complexion_corporalFilter { set; get; }
        public string Complexion_corporal { set; get; }

        public Filters Interpretacion_complexion_corporalFilter { set; get; }
        public string AdvanceInterpretacion_complexion_corporal { set; get; }
        public int[] AdvanceInterpretacion_complexion_corporalMultiple { set; get; }

        public Filters Distribucion_de_grasa_corporalFilter { set; get; }
        public string Distribucion_de_grasa_corporal { set; get; }

        public Filters Interpretacion_grasa_corporalFilter { set; get; }
        public string AdvanceInterpretacion_grasa_corporal { set; get; }
        public int[] AdvanceInterpretacion_grasa_corporalMultiple { set; get; }

        public Filters Indice_cintura_caderaFilter { set; get; }
        public string Indice_cintura_cadera { set; get; }

        public Filters Interpretacion_indiceFilter { set; get; }
        public string AdvanceInterpretacion_indice { set; get; }
        public int[] AdvanceInterpretacion_indiceMultiple { set; get; }

        public Filters Consumo_de_agua_resultadoFilter { set; get; }
        public string Consumo_de_agua_resultado { set; get; }

        public Filters Interpretacion_aguaFilter { set; get; }
        public string AdvanceInterpretacion_agua { set; get; }
        public int[] AdvanceInterpretacion_aguaMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFrecuencia_cardiaca_en_Esfuerzo { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFrecuencia_cardiaca_en_Esfuerzo", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFrecuencia_cardiaca_en_Esfuerzo { set; get; }

        public Filters Interpretacion_frecuenciaFilter { set; get; }
        public string AdvanceInterpretacion_frecuencia { set; get; }
        public int[] AdvanceInterpretacion_frecuenciaMultiple { set; get; }

        public Filters Dificultad_de_Rutina_de_EjerciciosFilter { set; get; }
        public string Dificultad_de_Rutina_de_Ejercicios { set; get; }

        public Filters Interpretacion_dificultadFilter { set; get; }
        public string AdvanceInterpretacion_dificultad { set; get; }
        public int[] AdvanceInterpretacion_dificultadMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCalorias { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCalorias", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCalorias { set; get; }

        public Filters Interpretacion_caloriasFilter { set; get; }
        public string AdvanceInterpretacion_calorias { set; get; }
        public int[] AdvanceInterpretacion_caloriasMultiple { set; get; }

        public Filters ObservacionesFilter { set; get; }
        public string Observaciones { set; get; }


    }
}
