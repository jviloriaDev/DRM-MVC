using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_FormatPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "FormatId":
                    return "Spartan_Format.FormatId";
                case "Registration_Date":
                    return "Spartan_Format.Registration_Date";
                case "Registration_Hour":
                    return "Spartan_Format.Registration_Hour";
                case "Registration_User":
                    return "Spartan_Format.Registration_User";
                case "Format_Name":
                    return "Spartan_Format.Format_Name";
                case "Format_Type[Description]":
                case "Format_TypeDescription":
                    return "Spartan_Format_Type.Description";
                case "Search":
                    return "Spartan_Format.Search";
                case "ObjectName":
                    return "Spartan_Format.Object";
                case "Header":
                    return "Spartan_Format.Header";
                case "Body":
                    return "Spartan_Format.Body";
                case "Footer":
                    return "Spartan_Format.Footer";

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

