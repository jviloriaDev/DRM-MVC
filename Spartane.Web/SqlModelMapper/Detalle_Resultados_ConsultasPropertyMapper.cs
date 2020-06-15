using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Resultados_Consultas;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Resultados_ConsultasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Resultados_Consultas.Folio";
                case "Folio_Pacientes[Nombre_Completo]":
                case "Folio_PacientesNombre_Completo":
                    return "Pacientes.Nombre_Completo";
                case "Fecha_de_Consulta":
                    return "Detalle_Resultados_Consultas.Fecha_de_Consulta";
                case "Indicador[Nombre]":
                case "IndicadorNombre":
                    return "Indicadores_Consultas.Nombre";
                case "Resultado":
                    return "Detalle_Resultados_Consultas.Resultado";
                case "Interpretacion":
                    return "Detalle_Resultados_Consultas.Interpretacion";
                case "IMC":
                    return "Detalle_Resultados_Consultas.IMC";
                case "IMC_Pediatria":
                    return "Detalle_Resultados_Consultas.IMC_Pediatria";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Resultados_Consultas).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Consulta")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
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

