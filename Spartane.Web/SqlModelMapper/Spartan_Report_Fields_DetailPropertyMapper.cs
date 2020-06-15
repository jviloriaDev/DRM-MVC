using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Report_Fields_DetailPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "DesignDetailId":
                    return "Spartan_Report_Fields_Detail.DesignDetailId";
                case "PathField":
                    return "Spartan_Report_Fields_Detail.PathField";
                case "Physical_Name":
                    return "Spartan_Report_Fields_Detail.Physical_Name";
                case "Title":
                    return "Spartan_Report_Fields_Detail.Title";
                case "Function[Description]":
                case "FunctionDescription":
                    return "Spartan_Report_Function.Description";
                case "Format[Description]":
                case "FormatDescription":
                    return "Spartan_Report_Format.Description";
                case "Order_Type[Description]":
                case "Order_TypeDescription":
                    return "Spartan_Report_Order_Type.Description";
                case "Field_Type[Description]":
                case "Field_TypeDescription":
                    return "Spartan_Report_Field_Type.Description";
                case "Order_Number":
                    return "Spartan_Report_Fields_Detail.Order_Number";
                case "AttributeId[Physical_Name]":
                case "AttributeIdPhysical_Name":
                    return "Spartan_Metadata.Physical_Name";

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

