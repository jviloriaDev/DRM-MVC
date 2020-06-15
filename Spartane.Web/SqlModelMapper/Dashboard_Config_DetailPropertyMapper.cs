using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Dashboard_Config_Detail;

namespace Spartane.Web.SqlModelMapper
{
    public class Dashboard_Config_DetailPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Detail_Id":
                    return "Dashboard_Config_Detail.Detail_Id";
                case "Report_Id":
                    return "Dashboard_Config_Detail.Report_Id";
                case "Report_Name":
                    return "Dashboard_Config_Detail.Report_Name";
                case "ConfigRow":
                    return "Dashboard_Config_Detail.ConfigRow";
                case "ConfigColumn":
                    return "Dashboard_Config_Detail.ConfigColumn";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Dashboard_Config_Detail).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
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

