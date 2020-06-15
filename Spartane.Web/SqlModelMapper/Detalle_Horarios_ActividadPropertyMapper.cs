using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Horarios_Actividad;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Horarios_ActividadPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Horarios_Actividad.Folio";
                case "Reservada":
                    return "Detalle_Horarios_Actividad.Reservada";
                case "Numero_de_Cita":
                    return "Detalle_Horarios_Actividad.Numero_de_Cita";
                case "Hora_inicio":
                    return "Detalle_Horarios_Actividad.Hora_inicio";
                case "Hora_fin":
                    return "Detalle_Horarios_Actividad.Hora_fin";
                case "Horario":
                    return "Detalle_Horarios_Actividad.Horario";
                case "Codigo_de_Reservacion[Codigo_Reservacion]":
                case "Codigo_de_ReservacionCodigo_Reservacion":
                    return "Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion";
                case "Numero_de_Empleado":
                    return "Detalle_Horarios_Actividad.Numero_de_Empleado";
                case "Familiar_del_Empleado":
                    return "Detalle_Horarios_Actividad.Familiar_del_Empleado";
                case "Nombre_Completo":
                    return "Detalle_Horarios_Actividad.Nombre_Completo";
                case "Parentesco_con_el_Empleado[Descripcion]":
                case "Parentesco_con_el_EmpleadoDescripcion":
                    return "Parentescos_Empleados.Descripcion";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Edad":
                    return "Detalle_Horarios_Actividad.Edad";
                case "Estatus_de_la_Reservacion[Descripcion]":
                case "Estatus_de_la_ReservacionDescripcion":
                    return "Estatus_Reservaciones_Actividad.Descripcion";
                case "Asistio":
                    return "Detalle_Horarios_Actividad.Asistio";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Horarios_Actividad).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Reservada")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Familiar_del_Empleado")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Asistio")
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

