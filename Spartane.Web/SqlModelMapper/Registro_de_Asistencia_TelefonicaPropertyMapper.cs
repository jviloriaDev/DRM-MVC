using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Registro_de_Asistencia_Telefonica;

namespace Spartane.Web.SqlModelMapper
{
    public class Registro_de_Asistencia_TelefonicaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Registro_de_Asistencia_Telefonica.Folio";
                case "Fecha_de_llamada":
                    return "Registro_de_Asistencia_Telefonica.Fecha_de_llamada";
                case "Hora_de_llamada":
                    return "Registro_de_Asistencia_Telefonica.Hora_de_llamada";
                case "Usuario_que_llama[Name]":
                case "Usuario_que_llamaName":
                    return "Spartan_User.Name";
                case "Dispositivo":
                    return "Registro_de_Asistencia_Telefonica.Dispositivo";
                case "Nombre_Paciente[Nombre_Completo]":
                case "Nombre_PacienteNombre_Completo":
                    return "Pacientes.Nombre_Completo";
                case "Suscripcion[Nombre_del_Plan]":
                case "SuscripcionNombre_del_Plan":
                    return "Planes_de_Suscripcion.Nombre_del_Plan";
                case "Numero_telefonico_del_Paciente":
                    return "Registro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente";
                case "Correo_del_Paciente":
                    return "Registro_de_Asistencia_Telefonica.Correo_del_Paciente";
                case "Telefono_de_Asistencia_marcado":
                    return "Registro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado";
                case "Hora_inicio_de_la_Llamada":
                    return "Registro_de_Asistencia_Telefonica.Hora_inicio_de_la_Llamada";
                case "Hora_fin_de_la_Llamada":
                    return "Registro_de_Asistencia_Telefonica.Hora_fin_de_la_Llamada";
                case "Duracion_minutos":
                    return "Registro_de_Asistencia_Telefonica.Duracion_minutos";
                case "Asunto_de_la_Llamada[Descripcion]":
                case "Asunto_de_la_LlamadaDescripcion":
                    return "Asuntos_Asistencia_Telefonica.Descripcion";
                case "Atendio[Name]":
                case "AtendioName":
                    return "Spartan_User.Name";
                case "Comentarios":
                    return "Registro_de_Asistencia_Telefonica.Comentarios";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_Llamadas.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Registro_de_Asistencia_Telefonica).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_llamada")
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

