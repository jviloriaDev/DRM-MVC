﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Facturacion_Especialistas;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Facturacion_EspecialistasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Facturacion_Especialistas.Folio";
                case "Fecha_de_Registro":
                    return "Detalle_Facturacion_Especialistas.Fecha_de_Registro";
                case "Folio_Factura":
                    return "Detalle_Facturacion_Especialistas.Folio_Factura";
                case "Periodo_Facturado":
                    return "Detalle_Facturacion_Especialistas.Periodo_Facturado";
                case "Cantidad":
                    return "Detalle_Facturacion_Especialistas.Cantidad";
                case "Estatus":
                    return "Detalle_Facturacion_Especialistas.Estatus";
                case "Fecha_programada_de_Pago":
                    return "Detalle_Facturacion_Especialistas.Fecha_programada_de_Pago";
                case "Pagada":
                    return "Detalle_Facturacion_Especialistas.Pagada";
                case "Fecha_de_pago":
                    return "Detalle_Facturacion_Especialistas.Fecha_de_pago";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Facturacion_Especialistas).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Registro")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_programada_de_Pago")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Pagada")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Fecha_de_pago")
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

