using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Datos_Bancarios_Especialistas;

namespace Spartane.Web.SqlModelMapper
{
    public class Datos_Bancarios_EspecialistasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Datos_Bancarios_Especialistas.Folio";
                case "Banco[Nombre]":
                case "BancoNombre":
                    return "Bancos.Nombre";
                case "CLABE_Interbancaria":
                    return "Datos_Bancarios_Especialistas.CLABE_Interbancaria";
                case "Num_Cuenta":
                    return "Datos_Bancarios_Especialistas.Num_Cuenta";
                case "Nombre_del_Titular":
                    return "Datos_Bancarios_Especialistas.Nombre_del_Titular";
                case "Principal":
                    return "Datos_Bancarios_Especialistas.Principal";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Datos_Bancarios_Especialistas).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Principal")
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

