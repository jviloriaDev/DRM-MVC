using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_Actions_False_DetailPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "ActionsFalseDetailId":
                    return "Spartan_BR_Actions_False_Detail.ActionsFalseDetailId";
                case "Action_Classification[Description]":
                case "Action_ClassificationDescription":
                    return "Spartan_BR_Action_Classification.Description";
                case "Action[Description]":
                case "ActionDescription":
                    return "Spartan_BR_Action.Description";
                case "Action_Result[Description]":
                case "Action_ResultDescription":
                    return "Spartan_BR_Action_Result.Description";
                case "Parameter_1":
                    return "Spartan_BR_Actions_False_Detail.Parameter_1";
                case "Parameter_2":
                    return "Spartan_BR_Actions_False_Detail.Parameter_2";
                case "Parameter_3":
                    return "Spartan_BR_Actions_False_Detail.Parameter_3";
                case "Parameter_4":
                    return "Spartan_BR_Actions_False_Detail.Parameter_4";
                case "Parameter_5":
                    return "Spartan_BR_Actions_False_Detail.Parameter_5";

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

