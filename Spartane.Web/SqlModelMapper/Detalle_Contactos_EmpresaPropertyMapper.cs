using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Contactos_Empresa;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Contactos_EmpresaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Contactos_Empresa.Folio";
                case "Nombre_completo":
                    return "Detalle_Contactos_Empresa.Nombre_completo";
                case "Correo":
                    return "Detalle_Contactos_Empresa.Correo";
                case "Telefono":
                    return "Detalle_Contactos_Empresa.Telefono";
                case "Contacto_Principal":
                    return "Detalle_Contactos_Empresa.Contacto_Principal";
                case "Area[Nombre]":
                case "AreaNombre":
                    return "areas_Empresas.Nombre";
                case "Acceso_al_Sistema":
                    return "Detalle_Contactos_Empresa.Acceso_al_Sistema";
                case "Nombre_de_usuario":
                    return "Detalle_Contactos_Empresa.Nombre_de_usuario";
                case "Recibe_Alertas":
                    return "Detalle_Contactos_Empresa.Recibe_Alertas";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Contactos_Empresa).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Contacto_Principal")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Acceso_al_Sistema")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Recibe_Alertas")
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

