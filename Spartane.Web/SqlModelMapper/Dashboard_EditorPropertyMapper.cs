using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Dashboard_Editor;

namespace Spartane.Web.SqlModelMapper
{
    public class Dashboard_EditorPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Dashboard_Id":
                    return "Dashboard_Editor.Dashboard_Id";
                case "Registration_Date":
                    return "Dashboard_Editor.Registration_Date";
                case "Registration_User[Name]":
                case "Registration_UserName":
                    return "Spartan_User.Name";
                case "Name":
                    return "Dashboard_Editor.Name";
                case "Dashboard_Template[Description]":
                case "Dashboard_TemplateDescription":
                    return "Template_Dashboard_Editor.Description";
                case "Show_in_Home":
                    return "Dashboard_Editor.Show_in_Home";
                case "Status[Description]":
                case "StatusDescription":
                    return "Dashboard_Status.Description";
                case "Spartan_Object":
                    return "Dashboard_Editor.Spartan_Object";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Dashboard_Editor).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Registration_Date")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Show_in_Home")
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

