using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Planes_Alimenticios;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Planes_AlimenticiosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Planes_Alimenticios.Folio";
                case "Tiempo_de_Comida[Comida]":
                case "Tiempo_de_ComidaComida":
                    return "Tiempos_de_Comida.Comida";
                case "Numero_de_Dia[Dia]":
                case "Numero_de_DiaDia":
                    return "Dias_de_la_semana.Dia";
                case "Fecha":
                    return "Detalle_Planes_Alimenticios.Fecha";
                case "Platillo[Nombre_de_Platillo]":
                case "PlatilloNombre_de_Platillo":
                    return "Platillos.Nombre_de_Platillo";
                case "Modificado":
                    return "Detalle_Planes_Alimenticios.Modificado";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Planes_Alimenticios).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Modificado")
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

