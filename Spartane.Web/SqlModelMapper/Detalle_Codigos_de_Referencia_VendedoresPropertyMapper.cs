using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Codigos_de_Referencia_VendedoresPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Folio";
                case "Porcentaje_de_descuento":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Porcentaje_de_descuento";
                case "Fecha_inicio_vigencia":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Fecha_inicio_vigencia";
                case "Fecha_fin_vigencia":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Fecha_fin_vigencia";
                case "Cantidad_maxima_de_referenciados":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Cantidad_maxima_de_referenciados";
                case "Codigo_para_referenciados":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Codigo_para_referenciados";
                case "Autorizado":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Autorizado";
                case "Usuario_que_autoriza[Name]":
                case "Usuario_que_autorizaName":
                    return "Spartan_User.Name";
                case "Fecha_de_autorizacion":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Fecha_de_autorizacion";
                case "Hora_de_autorizacion":
                    return "Detalle_Codigos_de_Referencia_Vendedores.Hora_de_autorizacion";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Codigos_de_Referencia_Vendedores).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_inicio_vigencia")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin_vigencia")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Autorizado")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Fecha_de_autorizacion")
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

