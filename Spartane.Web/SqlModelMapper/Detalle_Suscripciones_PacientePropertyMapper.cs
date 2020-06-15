using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Suscripciones_Paciente;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Suscripciones_PacientePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Suscripciones_Paciente.Folio";
                case "Suscripcion[Nombre_del_Plan]":
                case "SuscripcionNombre_del_Plan":
                    return "Planes_de_Suscripcion.Nombre_del_Plan";
                case "Fecha_de_inicio":
                    return "Detalle_Suscripciones_Paciente.Fecha_de_inicio";
                case "Fecha_fin":
                    return "Detalle_Suscripciones_Paciente.Fecha_fin";
                case "Nombre_de_la_Suscripcion":
                    return "Detalle_Suscripciones_Paciente.Nombre_de_la_Suscripcion";
                case "Frecuencia_de_Pago[Nombre]":
                case "Frecuencia_de_PagoNombre":
                    return "Frecuencia_de_pago_Pacientes.Nombre";
                case "Costo":
                    return "Detalle_Suscripciones_Paciente.Costo";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_de_Suscripcion.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Suscripciones_Paciente).GetProperty(columnName));
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

