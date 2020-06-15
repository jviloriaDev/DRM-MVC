using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow_Conditions_by_State;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_WorkFlow_Conditions_by_StatePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Conditions_by_StateId":
                    return "Spartan_WorkFlow_Conditions_by_State.Conditions_by_StateId";
                case "Phase[Name]":
                case "PhaseName":
                    return "Spartan_WorkFlow_Phases.Name";
                case "State[Name]":
                case "StateName":
                    return "Spartan_WorkFlow_State.Name";
                case "Condition_Operator[Description]":
                case "Condition_OperatorDescription":
                    return "Spartan_WorkFlow_Condition_Operator.Description";
                case "Attribute[Logical_Name]":
                case "AttributeLogical_Name":
                    return "Spartan_Metadata.Logical_Name";
                case "Condition[Description]":
                case "ConditionDescription":
                    return "Spartan_WorkFlow_Condition.Description";
                case "Operator[Description]":
                case "OperatorDescription":
                    return "Spartan_WorkFlow_Operator.Description";
                case "Operator_Value":
                    return "Spartan_WorkFlow_Conditions_by_State.Operator_Value";
                case "Priority":
                    return "Spartan_WorkFlow_Conditions_by_State.Priority";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_WorkFlow_Conditions_by_State).GetProperty(columnName));
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

