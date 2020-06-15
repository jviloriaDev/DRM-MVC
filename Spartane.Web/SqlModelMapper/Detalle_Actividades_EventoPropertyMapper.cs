using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Actividades_Evento;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Actividades_EventoPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Actividades_Evento.Folio";
                case "Tipo_de_Actividad[Descripcion]":
                case "Tipo_de_ActividadDescripcion":
                    return "Tipos_de_Actividades.Descripcion";
                case "Especialidad[Especialidad]":
                case "EspecialidadEspecialidad":
                    return "Especialidades.Especialidad";
                case "Nombre_de_la_Actividad":
                    return "Detalle_Actividades_Evento.Nombre_de_la_Actividad";
                case "Descripcion":
                    return "Detalle_Actividades_Evento.Descripcion";
                case "Quien_imparte[Name]":
                case "Quien_imparteName":
                    return "Spartan_User.Name";
                case "Dia":
                    return "Detalle_Actividades_Evento.Dia";
                case "Hora_inicio":
                    return "Detalle_Actividades_Evento.Hora_inicio";
                case "Hora_fin":
                    return "Detalle_Actividades_Evento.Hora_fin";
                case "Tiene_receso":
                    return "Detalle_Actividades_Evento.Tiene_receso";
                case "Hora_inicio_receso":
                    return "Detalle_Actividades_Evento.Hora_inicio_receso";
                case "Hora_fin_receso":
                    return "Detalle_Actividades_Evento.Hora_fin_receso";
                case "Duracion_maxima_por_paciente_mins":
                    return "Detalle_Actividades_Evento.Duracion_maxima_por_paciente_mins";
                case "Cupo_limitado":
                    return "Detalle_Actividades_Evento.Cupo_limitado";
                case "Cupo_maximo":
                    return "Detalle_Actividades_Evento.Cupo_maximo";
                case "Ubicacion[Nombre]":
                case "UbicacionNombre":
                    return "Ubicaciones_Eventos_Empresa.Nombre";
                case "Estatus_de_la_Actividad[Descripcion]":
                case "Estatus_de_la_ActividadDescripcion":
                    return "Estatus_Actividades_Evento.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Actividades_Evento).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Dia")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Tiene_receso")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Cupo_limitado")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
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

