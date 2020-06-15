using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Registro_en_Actividad_EventoPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Registro_en_Actividad_Evento.Folio";
                case "Actividad[Nombre_de_la_Actividad]":
                case "ActividadNombre_de_la_Actividad":
                    return "Detalle_Actividades_Evento.Nombre_de_la_Actividad";
                case "Fecha":
                    return "Detalle_Registro_en_Actividad_Evento.Fecha";
                case "Horario":
                    return "Detalle_Registro_en_Actividad_Evento.Horario";
                case "Es_para_un_familiar":
                    return "Detalle_Registro_en_Actividad_Evento.Es_para_un_familiar";
                case "Numero_de_Empleado":
                    return "Detalle_Registro_en_Actividad_Evento.Numero_de_Empleado";
                case "Nombres":
                    return "Detalle_Registro_en_Actividad_Evento.Nombres";
                case "Apellido_Paterno":
                    return "Detalle_Registro_en_Actividad_Evento.Apellido_Paterno";
                case "Apellido_Materno":
                    return "Detalle_Registro_en_Actividad_Evento.Apellido_Materno";
                case "Nombre_Completo":
                    return "Detalle_Registro_en_Actividad_Evento.Nombre_Completo";
                case "Parentesco[Descripcion]":
                case "ParentescoDescripcion":
                    return "Parentescos_Empleados.Descripcion";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Fecha_de_nacimiento":
                    return "Detalle_Registro_en_Actividad_Evento.Fecha_de_nacimiento";
                case "Estatus_de_la_Reservacion[Descripcion]":
                case "Estatus_de_la_ReservacionDescripcion":
                    return "Estatus_Reservaciones_Actividad.Descripcion";
                case "Codigo_Reservacion":
                    return "Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Registro_en_Actividad_Evento).GetProperty(columnName));
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
            if (columnName == "Es_para_un_familiar")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
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

