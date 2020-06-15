using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_de_Padecimientos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_de_PadecimientosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_de_Padecimientos.Folio";
                case "Padecimiento[Descripcion]":
                case "PadecimientoDescripcion":
                    return "Padecimientos.Descripcion";
                case "Tiempo_con_el_diagnostico[Descripcion]":
                case "Tiempo_con_el_diagnosticoDescripcion":
                    return "Tiempo_Padecimiento.Descripcion";
                case "Intervencion_quirurgica[Descripcion]":
                case "Intervencion_quirurgicaDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Tratamiento":
                    return "Detalle_de_Padecimientos.Tratamiento";
                case "Estado_actual[Descripcion]":
                case "Estado_actualDescripcion":
                    return "Estatus_Padecimiento.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_de_Padecimientos).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {


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

