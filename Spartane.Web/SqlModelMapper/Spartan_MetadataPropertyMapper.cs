using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_MetadataPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "AttributeId":
                    return "Spartan_Metadata.AttributeId";
                case "Class_Id":
                    return "Spartan_Metadata.Class_Id";
                case "Class_Name":
                    return "Spartan_Metadata.Class_Name";
                case "Object_Id":
                    return "Spartan_Metadata.Object_Id";
                case "Physical_Name":
                    return "Spartan_Metadata.Physical_Name";
                case "Logical_Name":
                    return "Spartan_Metadata.Logical_Name";
                case "Identifier_Type":
                    return "Spartan_Metadata.Identifier_Type";
                case "Attribute_Type":
                    return "Spartan_Metadata.Attribute_Type";
                case "Length":
                    return "Spartan_Metadata.Length";
                case "Decimals_Length":
                    return "Spartan_Metadata.Decimals_Length";
                case "Relation_Type":
                    return "Spartan_Metadata.Relation_Type";
                case "Related_Object_Id":
                    return "Spartan_Metadata.Related_Object_Id";
                case "Related_Class_Id":
                    return "Spartan_Metadata.Related_Class_Id";
                case "Related_Class_Name":
                    return "Spartan_Metadata.Related_Class_Name";
                case "Related_Class_Identifier":
                    return "Spartan_Metadata.Related_Class_Identifier";
                case "Related_Class_Description":
                    return "Spartan_Metadata.Related_Class_Description";
                case "Required":
                    return "Spartan_Metadata.Required";
                case "DefaultValue":
                    return "Spartan_Metadata.DefaultValue";
                case "Visible":
                    return "Spartan_Metadata.Visible";
                case "Help_Text":
                    return "Spartan_Metadata.Help_Text";
                case "Read_Only":
                    return "Spartan_Metadata.Read_Only";
                case "ScreenOrder":
                    return "Spartan_Metadata.ScreenOrder";
                case "Control_Type":
                    return "Spartan_Metadata.Control_Type";
                case "Group_Name":
                    return "Spartan_Metadata.Group_Name";

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
            if (columnName == "Required")
            {
                value = Convert.ToString(value) == "true" ? 1 : 0;
            }
            if (columnName == "Visible")
            {
                value = Convert.ToString(value) == "true" ? 1 : 0;
            }
            if (columnName == "Read_Only")
            {
                value = Convert.ToString(value) == "true" ? 1 : 0;
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

