using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_UserPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Id_User":
                    return "Spartan_User.Id_User";
                case "Name":
                    return "Spartan_User.Name";
                case "Role[Description]":
                case "RoleDescription":
                    return "Spartan_User_Role.Description";
                case "Email":
                    return "Spartan_User.Email";
                case "Status[Description]":
                case "StatusDescription":
                    return "Spartan_User_Status.Description";
                case "Username":
                    return "Spartan_User.Username";
                case "Password":
                    return "Spartan_User.Password";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_User).GetProperty(columnName));
            if (t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
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

