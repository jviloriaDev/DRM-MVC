using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Antecedentes_No_PatologicosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Antecedentes_No_Patologicos.Folio";
                case "Sustancia[Descripcion]":
                case "SustanciaDescripcion":
                    return "Sustancias.Descripcion";
                case "Frecuencia[Descripcion]":
                case "FrecuenciaDescripcion":
                    return "Frecuencia_Sustancias.Descripcion";
                case "Cantidad":
                    return "Detalle_Antecedentes_No_Patologicos.Cantidad";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Antecedentes_No_Patologicos).GetProperty(columnName));
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

