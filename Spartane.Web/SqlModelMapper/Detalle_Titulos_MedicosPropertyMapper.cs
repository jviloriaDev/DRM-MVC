using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Titulos_Medicos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Titulos_MedicosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Titulos_Medicos.Folio";
                case "Nombre_del_Titulo":
                    return "Detalle_Titulos_Medicos.Nombre_del_Titulo";
                case "Institucion_Facultad":
                    return "Detalle_Titulos_Medicos.Institucion_Facultad";
                case "Fecha_de_Titulacion":
                    return "Detalle_Titulos_Medicos.Fecha_de_Titulacion";
                case "Numero_de_Cedula":
                    return "Detalle_Titulos_Medicos.Numero_de_Cedula";
                case "Fecha_de_Expedicion":
                    return "Detalle_Titulos_Medicos.Fecha_de_Expedicion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Titulos_Medicos).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Titulacion")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_Expedicion")
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

