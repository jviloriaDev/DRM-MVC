using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_Attribute_Restrictions_DetailPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "RestrictionId":
                    return "Spartan_BR_Attribute_Restrictions_Detail.RestrictionId";
                case "Attribute_Type[Description]":
                case "Attribute_TypeDescription":
                    return "Spartan_Attribute_Type.Description";
                case "Control_Type[Description]":
                case "Control_TypeDescription":
                    return "Spartan_Attribute_Control_Type.Description";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            return SqlOperationType.Contains;
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

