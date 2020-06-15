using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Duracion_de_Planes_de_Suscripcion;

namespace Spartane.Web.SqlModelMapper
{
    public class Duracion_de_Planes_de_SuscripcionPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Duracion_de_Planes_de_Suscripcion.Clave";
                case "Nombre":
                    return "Duracion_de_Planes_de_Suscripcion.Nombre";
                case "Cantidad_en_Meses":
                    return "Duracion_de_Planes_de_Suscripcion.Cantidad_en_Meses";
                case "Cantidad_en_Dias":
                    return "Duracion_de_Planes_de_Suscripcion.Cantidad_en_Dias";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Duracion_de_Planes_de_Suscripcion).GetProperty(columnName));
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

