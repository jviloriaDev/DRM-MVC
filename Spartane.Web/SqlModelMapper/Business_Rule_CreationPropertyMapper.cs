using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Business_Rule_Creation;

namespace Spartane.Web.SqlModelMapper
{
    public class Business_Rule_CreationPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Key_Business_Rule_Creation":
                    return "Business_Rule_Creation.Key_Business_Rule_Creation";
                case "User[Name]":
                case "UserName":
                    return "Spartan_User.Name";
                case "Creation_Date":
                    return "Business_Rule_Creation.Creation_Date";
                case "Creation_Hour":
                    return "Business_Rule_Creation.Creation_Hour";
                case "Last_Updated_Date":
                    return "Business_Rule_Creation.Last_Updated_Date";
                case "Last_Updated_Hour":
                    return "Business_Rule_Creation.Last_Updated_Hour";
                case "Time_that_took":
                    return "Business_Rule_Creation.Time_that_took";
                case "Name":
                    return "Business_Rule_Creation.Name";
                case "Status[Description]":
                case "StatusDescription":
                    return "Spartan_BR_Status.Description";
                case "Complexity[Description]":
                case "ComplexityDescription":
                    return "Spartan_BR_Complexity.Description";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Business_Rule_Creation).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Creation_Date")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Last_Updated_Date")
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

