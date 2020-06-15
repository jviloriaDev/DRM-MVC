using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Consulta_Actividades_Registro_EventoPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Consulta_Actividades_Registro_Evento.Folio";
                case "Actividad[Nombre_de_la_Actividad]":
                case "ActividadNombre_de_la_Actividad":
                    return "Detalle_Actividades_Evento.Nombre_de_la_Actividad";
                case "Tipo_de_Actividad[Descripcion]":
                case "Tipo_de_ActividadDescripcion":
                    return "Tipos_de_Actividades.Descripcion";
                case "Especialidad[Especialidad]":
                case "EspecialidadEspecialidad":
                    return "Especialidades.Especialidad";
                case "Imparte[Name]":
                case "ImparteName":
                    return "Spartan_User.Name";
                case "Fecha":
                    return "Detalle_Consulta_Actividades_Registro_Evento.Fecha";
                case "Lugares_disponibles":
                    return "Detalle_Consulta_Actividades_Registro_Evento.Lugares_disponibles";
                case "Horarios_disponibles":
                    return "Detalle_Consulta_Actividades_Registro_Evento.Horarios_disponibles";
                case "Ubicacion":
                    return "Detalle_Consulta_Actividades_Registro_Evento.Ubicacion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Consulta_Actividades_Registro_Evento).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha")
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

