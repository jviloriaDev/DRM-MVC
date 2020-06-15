using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_de_Ingredientes;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_de_IngredientesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Detalle_de_Ingredientes.Clave";
                case "Cantidad":
                    return "Detalle_de_Ingredientes.Cantidad";
                case "Unidad[Unidad]":
                case "UnidadUnidad":
                    return "Unidades_de_Medida.Unidad";
                case "Nombre_del_Ingrediente[Nombre_Ingrediente]":
                case "Nombre_del_IngredienteNombre_Ingrediente":
                    return "Ingredientes.Nombre_Ingrediente";
                case "Nombre_de_presentacion[Descripcion]":
                case "Nombre_de_presentacionDescripcion":
                    return "Presentacion.Descripcion";
                case "Nombre_de_Marca[Descripcion]":
                case "Nombre_de_MarcaDescripcion":
                    return "Marca.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_de_Ingredientes).GetProperty(columnName));
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

