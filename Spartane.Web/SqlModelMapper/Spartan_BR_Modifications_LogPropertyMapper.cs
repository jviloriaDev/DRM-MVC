using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_BR_Modifications_LogPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "ModificationId":
                    return "Spartan_BR_Modifications_Log.ModificationId";
                case "Modification_Date":
                    return "Spartan_BR_Modifications_Log.Modification_Date";
                case "Modification_Hour":
                    return "Spartan_BR_Modifications_Log.Modification_Hour";
                case "Modification_User":
                    return "Spartan_BR_Modifications_Log.Modification_User";
                case "Comments":
                    return "Spartan_BR_Modifications_Log.Comments";
                case "Implementation_Code":
                    return "Spartan_BR_Modifications_Log.Implementation_Code";

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
            if (columnName == "Modification_Date")
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

