using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_WorkFlowPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "WorkFlowId":
                    return "Spartan_WorkFlow.WorkFlowId";
                case "Name":
                    return "Spartan_WorkFlow.Name";
                case "Description":
                    return "Spartan_WorkFlow.Description";
                case "Objective":
                    return "Spartan_WorkFlow.Objective";
                case "Status[Description]":
                case "StatusDescription":
                    return "Spartan_WorkFlow_Status.Description";
                case "Object[Name]":
                case "ObjectName":
                    return "Spartan_Object.Name";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_WorkFlow).GetProperty(columnName));
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

