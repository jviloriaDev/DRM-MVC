using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Traduction_Detail;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Traduction_DetailPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "IdTraductionDetail":
                    return "Spartan_Traduction_Detail.IdTraductionDetail";
                case "Concept[Concept_Description]":
                case "ConceptConcept_Description":
                    return "Spartan_Traduction_Concept_Type.Concept_Description";
                case "IdConcept":
                    return "Spartan_Traduction_Detail.IdConcept";
                case "Original_Text":
                    return "Spartan_Traduction_Detail.Original_Text";
                case "Translated_Text":
                    return "Spartan_Traduction_Detail.Translated_Text";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_Traduction_Detail).GetProperty(columnName));
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

