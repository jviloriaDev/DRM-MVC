using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio";
                case "Plan_de_Suscripcion[Descripcion]":
                case "Plan_de_SuscripcionDescripcion":
                    return "Planes_de_Suscripcion_Proveedores.Descripcion";
                case "Fecha_inicio":
                    return "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Fecha_inicio";
                case "Fecha_fin":
                    return "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Fecha_fin";
                case "Costo":
                    return "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Costo";
                case "Firmo_Contrato":
                    return "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Firmo_Contrato";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_de_Suscripcion.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Suscripcion_Red_de_Especialistas_Proveedores).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_inicio")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Firmo_Contrato")
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

