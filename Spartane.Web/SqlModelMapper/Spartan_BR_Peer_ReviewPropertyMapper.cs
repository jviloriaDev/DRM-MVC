using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Peer_Review;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_Peer_ReviewPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Key_Peer_Review":
                    return "Spartan_BR_Peer_Review.Key_Peer_Review";
                case "User_that_reviewed[Name]":
                case "User_that_reviewedName":
                    return "Spartan_User.Name";
                case "Acceptance_Criteria":
                    return "Spartan_BR_Peer_Review.Acceptance_Criteria";
                case "It_worked":
                    return "Spartan_BR_Peer_Review.It_worked";
                case "Rejection_reason[Description]":
                case "Rejection_reasonDescription":
                    return "Spartan_BR_Rejection_Reason.Description";
                case "Comments":
                    return "Spartan_BR_Peer_Review.Comments";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_BR_Peer_Review).GetProperty(columnName));
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

