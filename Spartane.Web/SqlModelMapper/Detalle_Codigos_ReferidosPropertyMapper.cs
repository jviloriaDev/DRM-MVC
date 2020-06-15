using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Codigos_Referidos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Codigos_ReferidosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Codigos_Referidos.Folio";
                case "Suscripcion[Nombre_del_Plan]":
                case "SuscripcionNombre_del_Plan":
                    return "Planes_de_Suscripcion.Nombre_del_Plan";
                case "Porcentaje_de_descuento":
                    return "Detalle_Codigos_Referidos.Porcentaje_de_descuento";
                case "Fecha_inicio_vigencia":
                    return "Detalle_Codigos_Referidos.Fecha_inicio_vigencia";
                case "Fecha_fin_vigencia":
                    return "Detalle_Codigos_Referidos.Fecha_fin_vigencia";
                case "Cantidad_maxima_de_referenciados":
                    return "Detalle_Codigos_Referidos.Cantidad_maxima_de_referenciados";
                case "Codigo_para_Referenciados":
                    return "Detalle_Codigos_Referidos.Codigo_para_Referenciados";
                case "Autorizado":
                    return "Detalle_Codigos_Referidos.Autorizado";
                case "Usuario_que_autoriza[Name]":
                case "Usuario_que_autorizaName":
                    return "Spartan_User.Name";
                case "Fecha_de_autorizacion":
                    return "Detalle_Codigos_Referidos.Fecha_de_autorizacion";
                case "Hora_de_autorizacion":
                    return "Detalle_Codigos_Referidos.Hora_de_autorizacion";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Codigos_Referidos).GetProperty(columnName));
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

