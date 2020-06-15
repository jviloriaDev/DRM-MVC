using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;

namespace Spartane.Web.SqlModelMapper
{
    public class Ubicaciones_Eventos_EmpresaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Ubicaciones_Eventos_Empresa.Folio";
                case "Fecha_de_Registro":
                    return "Ubicaciones_Eventos_Empresa.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Ubicaciones_Eventos_Empresa.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre":
                    return "Ubicaciones_Eventos_Empresa.Nombre";
                case "Descripcion":
                    return "Ubicaciones_Eventos_Empresa.Descripcion";
                case "Cupo":
                    return "Ubicaciones_Eventos_Empresa.Cupo";
                case "Ubicacion_externa[Descripcion]":
                case "Ubicacion_externaDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Nombre_del_Lugar":
                    return "Ubicaciones_Eventos_Empresa.Nombre_del_Lugar";
                case "Empresa[Nombre_de_la_Empresa]":
                case "EmpresaNombre_de_la_Empresa":
                    return "Empresas.Nombre_de_la_Empresa";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Ubicaciones_Eventos_Empresa).GetProperty(columnName));
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

