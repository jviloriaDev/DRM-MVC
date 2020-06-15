using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Testing;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_TestingPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Key_Testing":
                    return "Spartan_BR_Testing.Key_Testing";
                case "User_that_reviewed[Name]":
                case "User_that_reviewedName":
                    return "Spartan_User.Name";
                case "Acceptance_Critera":
                    return "Spartan_BR_Testing.Acceptance_Critera";
                case "It_worked":
                    return "Spartan_BR_Testing.It_worked";
                case "Rejection_Reason[Description]":
                case "Rejection_ReasonDescription":
                    return "Spartan_BR_Rejection_Reason.Description";
                case "Comments":
                    return "Spartan_BR_Testing.Comments";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_BR_Testing).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "It_worked")
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

