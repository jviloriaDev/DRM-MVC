using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Platillos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_PlatillosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Platillos.Folio";
                case "Lleva_fracciones":
                    return "Detalle_Platillos.Lleva_fracciones";
                case "Cantidad":
                    return "Detalle_Platillos.Cantidad";
                case "Cantidad_fraccion[Cantidad]":
                case "Cantidad_fraccionCantidad":
                    return "Cantidad_fraccion_platillos.Cantidad";
                case "Unidad":
                    return "Detalle_Platillos.Unidad";
                case "Ingrediente[Nombre_Ingrediente]":
                case "IngredienteNombre_Ingrediente":
                    return "Ingredientes.Nombre_Ingrediente";
                case "Caracteristica":
                    return "Detalle_Platillos.Caracteristica";
                case "Unidad_SMAE":
                    return "Detalle_Platillos.Unidad_SMAE";
                case "Equivalente_Unidad_SMAE":
                    return "Detalle_Platillos.Equivalente_Unidad_SMAE";
                case "Porciones":
                    return "Detalle_Platillos.Porciones";
                case "Detalle":
                    return "Detalle_Platillos.Detalle";
                case "Detalle_Super":
                    return "Detalle_Platillos.Detalle_Super";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Platillos).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Lleva_fracciones")
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

