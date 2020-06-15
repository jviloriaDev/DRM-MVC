using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Pagos_Empresa;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Pagos_EmpresaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Pagos_Empresa.Folio";
                case "Suscripcion[Nombre_del_Plan]":
                case "SuscripcionNombre_del_Plan":
                    return "Planes_de_Suscripcion.Nombre_del_Plan";
                case "Concepto_de_Pago":
                    return "Detalle_Pagos_Empresa.Concepto_de_Pago";
                case "Fecha_de_Suscripcion":
                    return "Detalle_Pagos_Empresa.Fecha_de_Suscripcion";
                case "Numero_de_Pago":
                    return "Detalle_Pagos_Empresa.Numero_de_Pago";
                case "De_Total_de_Pagos":
                    return "Detalle_Pagos_Empresa.De_Total_de_Pagos";
                case "Fecha_Limite_de_Pago":
                    return "Detalle_Pagos_Empresa.Fecha_Limite_de_Pago";
                case "Recordatorio_dias":
                    return "Detalle_Pagos_Empresa.Recordatorio_dias";
                case "Forma_de_Pago[Nombre]":
                case "Forma_de_PagoNombre":
                    return "Formas_de_Pago.Nombre";
                case "Fecha_de_Pago":
                    return "Detalle_Pagos_Empresa.Fecha_de_Pago";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_de_Pago.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Pagos_Empresa).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Suscripcion")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_Limite_de_Pago")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_Pago")
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

