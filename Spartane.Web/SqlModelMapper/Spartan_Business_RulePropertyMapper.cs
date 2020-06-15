using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Business_RulePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "BusinessRuleId":
                    return "Spartan_Business_Rule.BusinessRuleId";
                case "Registration_Date":
                    return "Spartan_Business_Rule.Registration_Date";
                case "Registration_Hour":
                    return "Spartan_Business_Rule.Registration_Hour";
                case "User_who_registers":
                    return "Spartan_Business_Rule.User_who_registers";
                case "Description":
                    return "Spartan_Business_Rule.Description";
                case "Object":
                    return "Spartan_Business_Rule.Object";
                case "Attribute":
                    return "Spartan_Business_Rule.Attribute";
                case "Implementation_Code":
                    return "Spartan_Business_Rule.Implementation_Code";

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
            if (columnName == "Registration_Date")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception)
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

