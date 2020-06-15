using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Report_Advance_FilterPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Spartan_Report_Advance_Filter.Clave";
                case "Report[Report_Name]":
                case "ReportReport_Name":
                    return "Spartan_Report.Report_Name";
                case "AttributeId[Physical_Name]":
                case "AttributeIdPhysical_Name":
                    return "Spartan_Metadata.Physical_Name";
                case "Defect_Value_From":
                    return "Spartan_Report_Advance_Filter.Defect_Value_From";
                case "Defect_Value_To":
                    return "Spartan_Report_Advance_Filter.Defect_Value_To";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_Report_Advance_Filter).GetProperty(columnName));
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

