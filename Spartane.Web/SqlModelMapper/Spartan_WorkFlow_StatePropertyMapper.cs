using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow_State;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_WorkFlow_StatePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "StateId":
                    return "Spartan_WorkFlow_State.StateId";
                case "Phase[Name]":
                case "PhaseName":
                    return "Spartan_WorkFlow_Phases.Name";
                case "Attribute[Logical_Name]":
                case "AttributeLogical_Name":
                    return "Spartan_Metadata.Logical_Name";
                case "State_Code":
                    return "Spartan_WorkFlow_State.State_Code";
                case "Name":
                    return "Spartan_WorkFlow_State.Name";
                case "Value":
                    return "Spartan_WorkFlow_State.Value";
                case "Text":
                    return "Spartan_WorkFlow_State.Text";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_WorkFlow_State).GetProperty(columnName));
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

