using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_WorkFlow_Matrix_of_StatesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Matrix_of_StatesId":
                    return "Spartan_WorkFlow_Matrix_of_States.Matrix_of_StatesId";
                case "Phase[Name]":
                case "PhaseName":
                    return "Spartan_WorkFlow_Phases.Name";
                case "State[Name]":
                case "StateName":
                    return "Spartan_WorkFlow_State.Name";
                case "Attribute[Logical_Name]":
                case "AttributeLogical_Name":
                    return "Spartan_Metadata.Logical_Name";
                case "Visible":
                    return "Spartan_WorkFlow_Matrix_of_States.Visible";
                case "Required":
                    return "Spartan_WorkFlow_Matrix_of_States.Required";
                case "Read_Only":
                    return "Spartan_WorkFlow_Matrix_of_States.Read_Only";
                case "Label":
                    return "Spartan_WorkFlow_Matrix_of_States.Label";
                case "Default_Value":
                    return "Spartan_WorkFlow_Matrix_of_States.Default_Value";
                case "Help_Text":
                    return "Spartan_WorkFlow_Matrix_of_States.Help_Text";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_WorkFlow_Matrix_of_States).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Visible")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Required")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Read_Only")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }


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

