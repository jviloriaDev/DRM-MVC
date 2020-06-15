using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Planes_de_Suscripcion;

namespace Spartane.Web.SqlModelMapper
{
    public class Planes_de_SuscripcionPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Planes_de_Suscripcion.Folio";
                case "Fecha_de_Registro":
                    return "Planes_de_Suscripcion.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Planes_de_Suscripcion.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Tipo_de_Beneficiario[Nombre]":
                case "Tipo_de_BeneficiarioNombre":
                    return "Tipo_de_Plan_de_Suscripcion.Nombre";
                case "Nombre":
                    return "Planes_de_Suscripcion.Nombre";
                case "Nombre_del_Plan":
                    return "Planes_de_Suscripcion.Nombre_del_Plan";
                case "Duracion_en_meses":
                    return "Planes_de_Suscripcion.Duracion_en_meses";
                case "Duracion":
                    return "Planes_de_Suscripcion.Duracion";
                case "Dietas_por_mes":
                    return "Planes_de_Suscripcion.Dietas_por_mes";
                case "Rutinas_por_mes":
                    return "Planes_de_Suscripcion.Rutinas_por_mes";
                case "Costo_mensual":
                    return "Planes_de_Suscripcion.Costo_mensual";
                case "Precio_Final":
                    return "Planes_de_Suscripcion.Precio_Final";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Planes_de_Suscripcion).GetProperty(columnName));
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

