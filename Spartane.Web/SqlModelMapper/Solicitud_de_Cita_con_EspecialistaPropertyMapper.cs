using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista;

namespace Spartane.Web.SqlModelMapper
{
    public class Solicitud_de_Cita_con_EspecialistaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Solicitud_de_Cita_con_Especialista.Folio";
                case "Fecha_de_solicitud":
                    return "Solicitud_de_Cita_con_Especialista.Fecha_de_solicitud";
                case "Hora_de_solicitud":
                    return "Solicitud_de_Cita_con_Especialista.Hora_de_solicitud";
                case "Usuario_que_solicita[Name]":
                case "Usuario_que_solicitaName":
                    return "Spartan_User.Name";
                case "Nombre_Completo":
                    return "Solicitud_de_Cita_con_Especialista.Nombre_Completo";
                case "Correo_del_Paciente":
                    return "Solicitud_de_Cita_con_Especialista.Correo_del_Paciente";
                case "Celular_del_Paciente":
                    return "Solicitud_de_Cita_con_Especialista.Celular_del_Paciente";
                case "Especialista[Nombre_Completo]":
                case "EspecialistaNombre_Completo":
                    return "Medicos.Nombre_Completo";
                case "Correo_del_Especialista":
                    return "Solicitud_de_Cita_con_Especialista.Correo_del_Especialista";
                case "Correo_enviado":
                    return "Solicitud_de_Cita_con_Especialista.Correo_enviado";
                case "Fecha_de_Retroalimentacion":
                    return "Solicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion";
                case "Hora_de_Retroalimentacion":
                    return "Solicitud_de_Cita_con_Especialista.Hora_de_Retroalimentacion";
                case "Asististe_a_tu_cita[Descripcion]":
                case "Asististe_a_tu_citaDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Calificacion_Especialista[Descripcion]":
                case "Calificacion_EspecialistaDescripcion":
                    return "Calificacion.Descripcion";
                case "Motivo_no_concreto_cita[Descripcion]":
                case "Motivo_no_concreto_citaDescripcion":
                    return "Motivos.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Solicitud_de_Cita_con_Especialista).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_solicitud")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Correo_enviado")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Fecha_de_Retroalimentacion")
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

