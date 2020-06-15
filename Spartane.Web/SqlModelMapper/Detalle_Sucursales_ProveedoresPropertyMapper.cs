using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Sucursales_Proveedores;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Sucursales_ProveedoresPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Sucursales_Proveedores.Folio";
                case "Tipo_de_Sucursal[Descripcion]":
                case "Tipo_de_SucursalDescripcion":
                    return "Tipo_de_Sucursal.Descripcion";
                case "Email":
                    return "Detalle_Sucursales_Proveedores.Email";
                case "Telefono":
                    return "Detalle_Sucursales_Proveedores.Telefono";
                case "Calle":
                    return "Detalle_Sucursales_Proveedores.Calle";
                case "Numero_exterior":
                    return "Detalle_Sucursales_Proveedores.Numero_exterior";
                case "Numero_interior":
                    return "Detalle_Sucursales_Proveedores.Numero_interior";
                case "Colonia":
                    return "Detalle_Sucursales_Proveedores.Colonia";
                case "C_P_":
                    return "Detalle_Sucursales_Proveedores.C_P_";
                case "Ciudad":
                    return "Detalle_Sucursales_Proveedores.Ciudad";
                case "Estado":
                    return "Detalle_Sucursales_Proveedores.Estado";
                case "Pais":
                    return "Detalle_Sucursales_Proveedores.Pais";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Sucursales_Proveedores).GetProperty(columnName));
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

