using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Bitacora_SQL;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Bitacora_SQLPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Spartan_Bitacora_SQL.Folio";
                case "Id_User":
                    return "Spartan_Bitacora_SQL.Id_User";
                case "Type_SQL":
                    return "Spartan_Bitacora_SQL.Type_SQL";
                case "Register_Date":
                    return "Spartan_Bitacora_SQL.Register_Date";
                case "Computer_Name":
                    return "Spartan_Bitacora_SQL.Computer_Name";
                case "Server_Name":
                    return "Spartan_Bitacora_SQL.Server_Name";
                case "Database_Name":
                    return "Spartan_Bitacora_SQL.Database_Name";
                case "System_Name":
                    return "Spartan_Bitacora_SQL.System_Name";
                case "System_Version":
                    return "Spartan_Bitacora_SQL.System_Version";
                case "Windows_Version":
                    return "Spartan_Bitacora_SQL.Windows_Version";
                case "Command_SQL":
                    return "Spartan_Bitacora_SQL.Command_SQL";
                case "Folio_SQL":
                    return "Spartan_Bitacora_SQL.Folio_SQL";
                case "Object_Id":
                    return "Spartan_Bitacora_SQL.Object_Id";
                case "IP":
                    return "Spartan_Bitacora_SQL.IP";
                case "Json":
                    return "Spartan_Bitacora_SQL.Json";
                case "Result":
                    return "Spartan_Bitacora_SQL.Result";
                case "Error":
                    return "Spartan_Bitacora_SQL.Error";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_Bitacora_SQL).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Register_Date")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Result")
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

