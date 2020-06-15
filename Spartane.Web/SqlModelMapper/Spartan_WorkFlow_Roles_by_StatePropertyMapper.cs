using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_WorkFlow_Roles_by_StatePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Roles_by_StateId":
                    return "Spartan_WorkFlow_Roles_by_State.Roles_by_StateId";
                case "Phase[Name]":
                case "PhaseName":
                    return "Spartan_WorkFlow_Phases.Name";
                case "State[Name]":
                case "StateName":
                    return "Spartan_WorkFlow_State.Name";
                case "User_Role":
                    return "Spartan_WorkFlow_Roles_by_State.User_Role";
                case "Phase_Transition":
                    return "Spartan_WorkFlow_Roles_by_State.Phase_Transition";
                case "Permission_To_Consult":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_To_Consult";
                case "Permission_To_New":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_To_New";
                case "Permission_To_Modify":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_To_Modify";
                case "Permission_to_Delete":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_to_Delete";
                case "Permission_To_Export":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_To_Export";
                case "Permission_To_Print":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_To_Print";
                case "Permission_Settings":
                    return "Spartan_WorkFlow_Roles_by_State.Permission_Settings";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_WorkFlow_Roles_by_State).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Permission_To_Consult")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permission_To_New")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permission_To_Modify")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permission_to_Delete")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permission_To_Export")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permission_To_Print")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permission_Settings")
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

