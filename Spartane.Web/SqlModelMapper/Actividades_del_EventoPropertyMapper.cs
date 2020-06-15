using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Actividades_del_Evento;

namespace Spartane.Web.SqlModelMapper
{
    public class Actividades_del_EventoPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Actividades_del_Evento.Folio";
                case "Fecha_de_Registro":
                    return "Actividades_del_Evento.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Actividades_del_Evento.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Evento[Nombre_del_Evento]":
                case "EventoNombre_del_Evento":
                    return "Eventos.Nombre_del_Evento";
                case "Actividad[Nombre_de_la_Actividad]":
                case "ActividadNombre_de_la_Actividad":
                    return "Detalle_Actividades_Evento.Nombre_de_la_Actividad";
                case "Descripcion":
                    return "Actividades_del_Evento.Descripcion";
                case "Dia":
                    return "Actividades_del_Evento.Dia";
                case "Hora_inicio":
                    return "Actividades_del_Evento.Hora_inicio";
                case "Hora_fin":
                    return "Actividades_del_Evento.Hora_fin";
                case "Tiene_receso":
                    return "Actividades_del_Evento.Tiene_receso";
                case "Hora_inicio_receso":
                    return "Actividades_del_Evento.Hora_inicio_receso";
                case "Hora_fin_receso":
                    return "Actividades_del_Evento.Hora_fin_receso";
                case "Ubicacion[Nombre]":
                case "UbicacionNombre":
                    return "Ubicaciones_Eventos_Empresa.Nombre";
                case "Tipo_de_Actividad[Descripcion]":
                case "Tipo_de_ActividadDescripcion":
                    return "Tipos_de_Actividades.Descripcion";
                case "Quien_imparte[Name]":
                case "Quien_imparteName":
                    return "Spartan_User.Name";
                case "Especialidad[Especialidad]":
                case "EspecialidadEspecialidad":
                    return "Especialidades.Especialidad";
                case "Cupo_limitado":
                    return "Actividades_del_Evento.Cupo_limitado";
                case "Cupo_maximo":
                    return "Actividades_del_Evento.Cupo_maximo";
                case "Duracion_maxima_por_Paciente_mins":
                    return "Actividades_del_Evento.Duracion_maxima_por_Paciente_mins";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_Actividades_Evento.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Actividades_del_Evento).GetProperty(columnName));
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

