using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_ReportPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "ReportId":
                    return "Spartan_Report.ReportId";
                case "Registration_Date":
                    return "Spartan_Report.Registration_Date";
                case "Registration_Hour":
                    return "Spartan_Report.Registration_Hour";
                case "Registration_User":
                    return "Spartan_Report.Registration_User";
                case "Object":
                    return "Spartan_Report.Object";
                case "Report_Name":
                    return "Spartan_Report.Report_Name";
                case "Presentation_Type[Description]":
                case "Presentation_TypeDescription":
                    return "Spartan_Report_Presentation_Type.Description";
                case "Presentation_View[Description]":
                case "Presentation_ViewDescription":
                    return "Spartan_Report_Presentation_View.Description";
                case "Status[Description]":
                case "StatusDescription":
                    return "Spartan_Report_Status.Description";
                case "Query":
                    return "Spartan_Report.Query";
                case "Filters":
                    return "Spartan_Report.Filters";
                case "Header":
                    return "Spartan_Report.Header";
                case "Footer":
                    return "Spartan_Report.Footer";

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

