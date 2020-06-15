using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Format_PermissionsPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "PermissionId":
                    return "Spartan_Format_Permissions.PermissionId";
                case "Format[Format_Name]":
                case "FormatFormat_Name":
                    return "Spartan_Format.Format_Name";
                case "Permission_Type[Description]":
                case "Permission_TypeDescription":
                    return "Spartan_Format_Permission_Type.Description";
                case "Apply":
                    return "Spartan_Format_Permissions.Apply";
                case "Spartan_User_Role":
                    return "Spartan_Format_Permissions.Spartan_User_Role";

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
            if (columnName == "Apply")
            {
                value = Convert.ToString(value) == "true" ? 1 : 0;
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

