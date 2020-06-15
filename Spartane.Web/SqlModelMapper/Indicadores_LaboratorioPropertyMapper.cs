using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Indicadores_Laboratorio;

namespace Spartane.Web.SqlModelMapper
{
    public class Indicadores_LaboratorioPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Indicadores_Laboratorio.Folio";
                case "Indicador":
                    return "Indicadores_Laboratorio.Indicador";
                case "Unidad_de_Medida":
                    return "Indicadores_Laboratorio.Unidad_de_Medida";
                case "Limite_inferior":
                    return "Indicadores_Laboratorio.Limite_inferior";
                case "Limite_superior":
                    return "Indicadores_Laboratorio.Limite_superior";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Indicadores_Laboratorio).GetProperty(columnName));
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

