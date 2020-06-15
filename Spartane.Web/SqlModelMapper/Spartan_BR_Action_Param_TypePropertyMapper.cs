using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_Action_Param_TypePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "ParameterTypeId":
                    return "Spartan_BR_Action_Param_Type.ParameterTypeId";
                case "Description":
                    return "Spartan_BR_Action_Param_Type.Description";
                case "Presentation_Control_Type[Description]":
                case "Presentation_Control_TypeDescription":
                    return "Spartan_BR_Presentation_Control_Type.Description";
                case "Query_for_Fill_Condition":
                    return "Spartan_BR_Action_Param_Type.Query_for_Fill_Condition";
                case "Code_for_Fill_Condition":
                    return "Spartan_BR_Action_Param_Type.Code_for_Fill_Condition";
                case "Implementation_Code":
                    return "Spartan_BR_Action_Param_Type.Implementation_Code";

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

