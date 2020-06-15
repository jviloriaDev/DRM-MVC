using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_Conditions_DetailPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "ConditionsDetailId":
                    return "Spartan_BR_Conditions_Detail.ConditionsDetailId";
                case "Condition_Operator[Description]":
                case "Condition_OperatorDescription":
                    return "Spartan_BR_Condition_Operator.Description";
                case "First_Operator_Type[Description]":
                case "First_Operator_TypeDescription":
                    return "Spartan_BR_Operator_Type.Description";
                case "First_Operator_Value":
                    return "Spartan_BR_Conditions_Detail.First_Operator_Value";
                case "Condition[Description]":
                case "ConditionDescription":
                    return "Spartan_BR_Condition.Description";
                case "Second_Operator_Type[Description]":
                case "Second_Operator_TypeDescription":
                    return "Spartan_BR_Operator_Type.Description";
                case "Second_Operator_Value":
                    return "Spartan_BR_Conditions_Detail.Second_Operator_Value";

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

