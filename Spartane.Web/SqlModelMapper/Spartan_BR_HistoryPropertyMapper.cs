using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_History;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_HistoryPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Key_History":
                    return "Spartan_BR_History.Key_History";
                case "User_logged[Name]":
                case "User_loggedName":
                    return "Spartan_User.Name";
                case "Status[Description]":
                case "StatusDescription":
                    return "Spartan_BR_Status.Description";
                case "Change_Date":
                    return "Spartan_BR_History.Change_Date";
                case "Hour_Date":
                    return "Spartan_BR_History.Hour_Date";
                case "Time_elapsed":
                    return "Spartan_BR_History.Time_elapsed";
                case "Change_Type[Description]":
                case "Change_TypeDescription":
                    return "Spartan_BR_Type_History.Description";
                case "Conditions":
                    return "Spartan_BR_History.Conditions";
                case "Actions_True":
                    return "Spartan_BR_History.Actions_True";
                case "Actions_False":
                    return "Spartan_BR_History.Actions_False";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_BR_History).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Change_Date")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
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

