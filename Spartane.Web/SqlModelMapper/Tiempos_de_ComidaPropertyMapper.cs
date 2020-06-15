using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Tiempos_de_Comida;

namespace Spartane.Web.SqlModelMapper
{
    public class Tiempos_de_ComidaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Tiempos_de_Comida.Clave";
                case "Comida":
                    return "Tiempos_de_Comida.Comida";
                case "Hora_min":
                    return "Tiempos_de_Comida.Hora_min";
                case "Hora_max":
                    return "Tiempos_de_Comida.Hora_max";
                case "Pais[Nombre_del_Pais]":
                case "PaisNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Tiempos_de_Comida).GetProperty(columnName));
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

