using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Planes_de_Suscripcion_EspecialistasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Planes_de_Suscripcion_Especialistas.Folio";
                case "Plan_de_Suscripcion[Nombre]":
                case "Plan_de_SuscripcionNombre":
                    return "Planes_de_Suscripcion_Especialistas.Nombre";
                case "Fecha_de_inicio":
                    return "Detalle_Planes_de_Suscripcion_Especialistas.Fecha_de_inicio";
                case "Fecha_fin":
                    return "Detalle_Planes_de_Suscripcion_Especialistas.Fecha_fin";
                case "Frecuencia_de_Pago[Nombre]":
                case "Frecuencia_de_PagoNombre":
                    return "Frecuencia_de_pago_Especialistas.Nombre";
                case "Costo":
                    return "Detalle_Planes_de_Suscripcion_Especialistas.Costo";
                case "Firmo_Contrato":
                    return "Detalle_Planes_de_Suscripcion_Especialistas.Firmo_Contrato";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_de_Suscripcion.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Planes_de_Suscripcion_Especialistas).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_inicio")
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

