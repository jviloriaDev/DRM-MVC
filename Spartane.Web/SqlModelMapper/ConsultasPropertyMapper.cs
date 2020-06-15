using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Consultas;

namespace Spartane.Web.SqlModelMapper
{
    public class ConsultasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Consultas.Folio";
                case "Fecha_de_Registo":
                    return "Consultas.Fecha_de_Registo";
                case "Hora_de_Registro":
                    return "Consultas.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Fecha_Programada":
                    return "Consultas.Fecha_Programada";
                case "Paciente[Nombre_Completo]":
                case "PacienteNombre_Completo":
                    return "Pacientes.Nombre_Completo";
                case "Edad":
                    return "Consultas.Edad";
                case "Nombre_del_padre":
                    return "Consultas.Nombre_del_padre";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Email":
                    return "Consultas.Email";
                case "Objetivo[Descripcion]":
                case "ObjetivoDescripcion":
                    return "Objetivos.Descripcion";
                case "Frecuencia_Cardiaca":
                    return "Consultas.Frecuencia_Cardiaca";
                case "Presion_sistolica":
                    return "Consultas.Presion_sistolica";
                case "Presion_diastolica":
                    return "Consultas.Presion_diastolica";
                case "Peso_actual":
                    return "Consultas.Peso_actual";
                case "Estatura":
                    return "Consultas.Estatura";
                case "Circunferencia_de_cintura_cm":
                    return "Consultas.Circunferencia_de_cintura_cm";
                case "Circunferencia_de_cadera_cm":
                    return "Consultas.Circunferencia_de_cadera_cm";
                case "Edad_Metabolica":
                    return "Consultas.Edad_Metabolica";
                case "Agua_corporal":
                    return "Consultas.Agua_corporal";
                case "Grasa_Visceral":
                    return "Consultas.Grasa_Visceral";
                case "Grasa_Corporal":
                    return "Consultas.Grasa_Corporal";
                case "Grasa_Corporal_kg":
                    return "Consultas.Grasa_Corporal_kg";
                case "Masa_Muscular_kg":
                    return "Consultas.Masa_Muscular_kg";
                case "Semana_de_gestacion":
                    return "Consultas.Semana_de_gestacion";
                case "IMC":
                    return "Consultas.IMC";
                case "IMC_Pediatria[Descripcion]":
                case "IMC_PediatriaDescripcion":
                    return "Interpretacion_IMC.Descripcion";
                case "Interpretacion_IMC[Descripcion]":
                case "Interpretacion_IMCDescripcion":
                    return "Interpretacion_IMC.Descripcion";
                case "Consumo_de_agua_resultado":
                    return "Consultas.Consumo_de_agua_resultado";
                case "Interpretacion_agua[Descripcion]":
                case "Interpretacion_aguaDescripcion":
                    return "Interpretacion_consumo_de_agua.Descripcion";
                case "Frecuencia_cardiaca_en_Esfuerzo":
                    return "Consultas.Frecuencia_cardiaca_en_Esfuerzo";
                case "Interpretacion_frecuencia[Descripcion]":
                case "Interpretacion_frecuenciaDescripcion":
                    return "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion";
                case "Indice_cintura_cadera":
                    return "Consultas.Indice_cintura_cadera";
                case "Interpretacion_indice[Descripcion]":
                case "Interpretacion_indiceDescripcion":
                    return "Interpretacion_indice_cintura__cadera.Descripcion";
                case "Dificultad_de_Rutina_de_Ejercicios":
                    return "Consultas.Dificultad_de_Rutina_de_Ejercicios";
                case "Interpretacion_dificultad[Descripcion]":
                case "Interpretacion_dificultadDescripcion":
                    return "Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion";
                case "Calorias":
                    return "Consultas.Calorias";
                case "Interpretacion_calorias[Descripcion]":
                case "Interpretacion_caloriasDescripcion":
                    return "Interpretacion_Calorias.Descripcion";
                case "Observaciones":
                    return "Consultas.Observaciones";
                case "Fecha_siguiente_Consulta":
                    return "Consultas.Fecha_siguiente_Consulta";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Consultas).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Registo")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_Programada")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_siguiente_Consulta")
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

