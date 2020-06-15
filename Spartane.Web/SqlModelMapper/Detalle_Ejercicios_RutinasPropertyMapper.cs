using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Ejercicios_Rutinas;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Ejercicios_RutinasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Ejercicios_Rutinas.Folio";
                case "Orden_de_realizacion":
                    return "Detalle_Ejercicios_Rutinas.Orden_de_realizacion";
                case "Numero_de_serie":
                    return "Detalle_Ejercicios_Rutinas.Numero_de_serie";
                case "Ejercicio[Nombre_del_Ejercicio]":
                case "EjercicioNombre_del_Ejercicio":
                    return "Ejercicios.Nombre_del_Ejercicio";
                case "Cantidad_de_Repeticiones":
                    return "Detalle_Ejercicios_Rutinas.Cantidad_de_Repeticiones";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Ejercicios_Rutinas).GetProperty(columnName));
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

