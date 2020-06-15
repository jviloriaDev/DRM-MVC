using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_WorkFlow_PhasesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "PhasesId":
                    return "Spartan_WorkFlow_Phases.PhasesId";
                case "Phase_Number":
                    return "Spartan_WorkFlow_Phases.Phase_Number";
                case "Name":
                    return "Spartan_WorkFlow_Phases.Name";
                case "Phase_Type[Description]":
                case "Phase_TypeDescription":
                    return "Spartan_WorkFlow_Phase_Type.Description";
                case "Type_of_Work_Distribution[Description]":
                case "Type_of_Work_DistributionDescription":
                    return "Spartan_WorkFlow_Type_Work_Distribution.Description";
                case "Type_Flow_Control[Description]":
                case "Type_Flow_ControlDescription":
                    return "Spartan_WorkFlow_Type_Flow_Control.Description";
                case "Phase_Status[Description]":
                case "Phase_StatusDescription":
                    return "Spartan_WorkFlow_Phase_Status.Description";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_WorkFlow_Phases).GetProperty(columnName));
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

