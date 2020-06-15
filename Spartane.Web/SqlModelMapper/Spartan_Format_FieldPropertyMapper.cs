using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Format_FieldPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "FormatFieldId":
                    return "Spartan_Format_Field.FormatFieldId";
                case "Format[Format_Name]":
                case "FormatFormat_Name":
                    return "Spartan_Format.Format_Name";
                case "Field_Path":
                    return "Spartan_Format_Field.Field_Path";
                case "Physical_Field_Name":
                    return "Spartan_Format_Field.Physical_Field_Name";
                case "Logical_Field_Name":
                    return "Spartan_Format_Field.Logical_Field_Name";
                case "Creation_Date":
                    return "Spartan_Format_Field.Creation_Date";
                case "Creation_Hour":
                    return "Spartan_Format_Field.Creation_Hour";
                case "Creation_User":
                    return "Spartan_Format_Field.Creation_User";
                case "Properties":
                    return "Spartan_Format_Field.Properties";

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
            if (columnName == "Creation_Date")
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

