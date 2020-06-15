using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Examenes_Laboratorio;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Examenes_LaboratorioPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Examenes_Laboratorio.Folio";
                case "Indicador[Indicador]":
                case "IndicadorIndicador":
                    return "Indicadores_Laboratorio.Indicador";
                case "Resultado":
                    return "Detalle_Examenes_Laboratorio.Resultado";
                case "Unidad":
                    return "Detalle_Examenes_Laboratorio.Unidad";
                case "Intervalo_de_Referencia":
                    return "Detalle_Examenes_Laboratorio.Intervalo_de_Referencia";
                case "Fecha_de_Resultado":
                    return "Detalle_Examenes_Laboratorio.Fecha_de_Resultado";
                case "Estatus_Indicador":
                    return "Detalle_Examenes_Laboratorio.Estatus_Indicador";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Examenes_Laboratorio).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Resultado")
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

