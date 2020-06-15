using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pacientes;

namespace Spartane.Web.SqlModelMapper
{
    public class PacientesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Pacientes.Folio";
                case "Fecha_de_Registro":
                    return "Pacientes.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Pacientes.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Tipo_de_Registro[Descripcion]":
                case "Tipo_de_RegistroDescripcion":
                    return "Tipo_de_Registro.Descripcion";
                case "Tipo_de_Paciente[Descripcion]":
                case "Tipo_de_PacienteDescripcion":
                    return "Tipo_Paciente.Descripcion";
                case "Usuario_Registrado[Name]":
                case "Usuario_RegistradoName":
                    return "Spartan_User.Name";
                case "Empresa[Nombre_de_la_Empresa]":
                case "EmpresaNombre_de_la_Empresa":
                    return "Empresas.Nombre_de_la_Empresa";
                case "Numero_de_Empleado":
                    return "Pacientes.Numero_de_Empleado";
                case "Nombres":
                    return "Pacientes.Nombres";
                case "Apellido_Paterno":
                    return "Pacientes.Apellido_Paterno";
                case "Apellido_Materno":
                    return "Pacientes.Apellido_Materno";
                case "Nombre_Completo":
                    return "Pacientes.Nombre_Completo";
                case "Celular":
                    return "Pacientes.Celular";
                case "Email":
                    return "Pacientes.Email";
                case "Fecha_de_nacimiento":
                    return "Pacientes.Fecha_de_nacimiento";
                case "Nombre_del_Padre_o_Tutor":
                    return "Pacientes.Nombre_del_Padre_o_Tutor";
                case "Pais_de_nacimiento[Nombre_del_Pais]":
                case "Pais_de_nacimientoNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Lugar_de_nacimiento[Nombre_del_Estado]":
                case "Lugar_de_nacimientoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Estado_Civil[Descripcion]":
                case "Estado_CivilDescripcion":
                    return "Estado_Civil.Descripcion";
                case "Calle":
                    return "Pacientes.Calle";
                case "Numero_exterior":
                    return "Pacientes.Numero_exterior";
                case "Numero_interior":
                    return "Pacientes.Numero_interior";
                case "Colonia":
                    return "Pacientes.Colonia";
                case "CP":
                    return "Pacientes.CP";
                case "Ciudad":
                    return "Pacientes.Ciudad";
                case "Pais[Nombre_del_Pais]":
                case "PaisNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Estado[Nombre_del_Estado]":
                case "EstadoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Ocupacion":
                    return "Pacientes.Ocupacion";
                case "Cantidad_hijos":
                    return "Pacientes.Cantidad_hijos";
                case "Objetivo[Descripcion]":
                case "ObjetivoDescripcion":
                    return "Objetivos.Descripcion";
                case "Estatus_Paciente[Descripcion]":
                case "Estatus_PacienteDescripcion":
                    return "Estatus_por_Suscripcion.Descripcion";
                case "Cuenta_con_padecimientos[Descripcion]":
                case "Cuenta_con_padecimientosDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Frecuencia_Cardiaca":
                    return "Pacientes.Frecuencia_Cardiaca";
                case "Frecuencia_Respiratoria":
                    return "Pacientes.Frecuencia_Respiratoria";
                case "Presion_sistolica":
                    return "Pacientes.Presion_sistolica";
                case "Presion_diastolica":
                    return "Pacientes.Presion_diastolica";
                case "Peso_actual":
                    return "Pacientes.Peso_actual";
                case "Estatura":
                    return "Pacientes.Estatura";
                case "Peso_habitual":
                    return "Pacientes.Peso_habitual";
                case "Circunferencia_de_cintura_cm":
                    return "Pacientes.Circunferencia_de_cintura_cm";
                case "Circunferencia_de_cadera_cm":
                    return "Pacientes.Circunferencia_de_cadera_cm";
                case "Anchura_de_muneca_mm":
                    return "Pacientes.Anchura_de_muneca_mm";
                case "Circunferencia_de_brazo_cm":
                    return "Pacientes.Circunferencia_de_brazo_cm";
                case "Pliegue_cutaneo_tricipital_mm":
                    return "Pacientes.Pliegue_cutaneo_tricipital_mm";
                case "Pliegue_cutaneo_bicipital_mm":
                    return "Pacientes.Pliegue_cutaneo_bicipital_mm";
                case "Pliegue_cutaneo_subescapular_mm":
                    return "Pacientes.Pliegue_cutaneo_subescapular_mm";
                case "Pliegue_cutaneo_supraespinal_mm":
                    return "Pacientes.Pliegue_cutaneo_supraespinal_mm";
                case "Edad_Metabolica":
                    return "Pacientes.Edad_Metabolica";
                case "Agua_corporal":
                    return "Pacientes.Agua_corporal";
                case "Grasa_Visceral":
                    return "Pacientes.Grasa_Visceral";
                case "Grasa_Corporal":
                    return "Pacientes.Grasa_Corporal";
                case "Grasa_Corporal_kg":
                    return "Pacientes.Grasa_Corporal_kg";
                case "Masa_Muscular_kg":
                    return "Pacientes.Masa_Muscular_kg";
                case "Masa_Muscular_":
                    return "Pacientes.Masa_Muscular_";
                case "Esta_embarazada[Descripcion]":
                case "Esta_embarazadaDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Semana_de_gestacion":
                    return "Pacientes.Semana_de_gestacion";
                case "Peso_pregestacional":
                    return "Pacientes.Peso_pregestacional";
                case "Toma_anticonceptivos[Descripcion]":
                case "Toma_anticonceptivosDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Nombre_del_Anticonceptivo":
                    return "Pacientes.Nombre_del_Anticonceptivo";
                case "Dosis":
                    return "Pacientes.Dosis";
                case "Climaterio[Descripcion]":
                case "ClimaterioDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Fecha_Climaterio":
                    return "Pacientes.Fecha_Climaterio";
                case "Terapia_reemplazo_hormonal[Descripcion]":
                case "Terapia_reemplazo_hormonalDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Tipo_Dieta[Descripcion]":
                case "Tipo_DietaDescripcion":
                    return "Tipo_de_Dieta.Descripcion";
                case "Suplementos[Descripcion]":
                case "SuplementosDescripcion":
                    return "Suplementos.Descripcion";
                case "Consumo_de_sal[Descripcion]":
                case "Consumo_de_salDescripcion":
                    return "Preferencias_Sal.Descripcion";
                case "Grasas_Preferencias[Descripcion]":
                case "Grasas_PreferenciasDescripcion":
                    return "Preferencias_Grasas.Descripcion";
                case "Comidas_cantidad[Descripcion]":
                case "Comidas_cantidadDescripcion":
                    return "Cantidad_Comidas.Descripcion";
                case "Preparacion_Preferencias[Descripcion]":
                case "Preparacion_PreferenciasDescripcion":
                    return "Preferencias_Preparacion.Descripcion";
                case "Entre_comidas[Descripcion]":
                case "Entre_comidasDescripcion":
                    return "Preferencias_Entrecomidas.Descripcion";
                case "Apetito[Descripcion]":
                case "ApetitoDescripcion":
                    return "Nivel_de_Satisfaccion.Descripcion";
                case "Habitos_Modificacion[Descripcion]":
                case "Habitos_ModificacionDescripcion":
                    return "Tipo_Modificacion_Alimentos.Descripcion";
                case "Horario_hambre[Descripcion]":
                case "Horario_hambreDescripcion":
                    return "Periodo_del_dia.Descripcion";
                case "Cuando_cambia_mi_estado_de_animo[Descripcion]":
                case "Cuando_cambia_mi_estado_de_animoDescripcion":
                    return "Estado_de_Animo.Descripcion";
                case "Medicamentos_bajar_peso[Descripcion]":
                case "Medicamentos_bajar_pesoDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Cual_medicamento":
                    return "Pacientes.Cual_medicamento";
                case "Frecuencia_Ejercicio[Descripcion]":
                case "Frecuencia_EjercicioDescripcion":
                    return "Frecuencia_Ejercicio.Descripcion";
                case "Duracion_Ejercicio[Descripcion]":
                case "Duracion_EjercicioDescripcion":
                    return "Duracion_Ejercicio.Descripcion";
                case "Tipo_Ejercicio[Descripcion]":
                case "Tipo_EjercicioDescripcion":
                    return "Tipo_Ejercicio.Descripcion";
                case "Antiguedad_Ejercicio[Descripcion]":
                case "Antiguedad_EjercicioDescripcion":
                    return "Antiguedad_Ejercicios.Descripcion";
                case "IMC":
                    return "Pacientes.IMC";
                case "Interpretacion_IMC[Descripcion]":
                case "Interpretacion_IMCDescripcion":
                    return "Interpretacion_IMC.Descripcion";
                case "IMC_Pediatria[Descripcion]":
                case "IMC_PediatriaDescripcion":
                    return "Interpretacion_IMC.Descripcion";
                case "Complexion_corporal":
                    return "Pacientes.Complexion_corporal";
                case "Interpretacion_complexion_corporal[Descripcion]":
                case "Interpretacion_complexion_corporalDescripcion":
                    return "Interpretacion_corporal.Descripcion";
                case "Distribucion_de_grasa_corporal":
                    return "Pacientes.Distribucion_de_grasa_corporal";
                case "Interpretacion_grasa_corporal[Descripcion]":
                case "Interpretacion_grasa_corporalDescripcion":
                    return "Interpretacion_distribucion_grasa_corporal.Descripcion";
                case "Indice_cintura_cadera":
                    return "Pacientes.Indice_cintura_cadera";
                case "Interpretacion_indice[Descripcion]":
                case "Interpretacion_indiceDescripcion":
                    return "Interpretacion_indice_cintura__cadera.Descripcion";
                case "Consumo_de_agua_resultado":
                    return "Pacientes.Consumo_de_agua_resultado";
                case "Interpretacion_agua[Descripcion]":
                case "Interpretacion_aguaDescripcion":
                    return "Interpretacion_consumo_de_agua.Descripcion";
                case "Frecuencia_cardiaca_en_Esfuerzo":
                    return "Pacientes.Frecuencia_cardiaca_en_Esfuerzo";
                case "Interpretacion_frecuencia[Descripcion]":
                case "Interpretacion_frecuenciaDescripcion":
                    return "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion";
                case "Dificultad_de_Rutina_de_Ejercicios":
                    return "Pacientes.Dificultad_de_Rutina_de_Ejercicios";
                case "Interpretacion_dificultad[Descripcion]":
                case "Interpretacion_dificultadDescripcion":
                    return "Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion";
                case "Calorias":
                    return "Pacientes.Calorias";
                case "Interpretacion_calorias[Descripcion]":
                case "Interpretacion_caloriasDescripcion":
                    return "Interpretacion_Calorias.Descripcion";
                case "Observaciones":
                    return "Pacientes.Observaciones";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Pacientes).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Registro")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_nacimiento")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_Climaterio")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }


            var operatorCondition = GetOperationType(columnName);
            columnName = GetPropertyName(columnName);

            switch (operatorCondition)
            {
                case SqlOperationType.Contains:
                    return string.IsNullOrEmpty(Convert.ToString(value)) ? "" : columnName + " LIKE '%" + value + "%'";
                case SqlOperationType.Equals:
                    return Convert.ToString(value) == "0" || Convert.ToString(value) == "" ? "" : columnName + "='" + value + "'";

            }
            return null;
        }
    }
}

