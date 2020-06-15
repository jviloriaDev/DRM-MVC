using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Empresas;

namespace Spartane.Web.SqlModelMapper
{
    public class EmpresasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Empresas.Folio";
                case "Fecha_de_Registro":
                    return "Empresas.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Empresas.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre_de_la_Empresa":
                    return "Empresas.Nombre_de_la_Empresa";
                case "Tipo_de_Empresa[Descripcion]":
                case "Tipo_de_EmpresaDescripcion":
                    return "Tipos_de_Empresa.Descripcion";
                case "Email":
                    return "Empresas.Email";
                case "Telefono":
                    return "Empresas.Telefono";
                case "Calle":
                    return "Empresas.Calle";
                case "Numero_exterior":
                    return "Empresas.Numero_exterior";
                case "Numero_interior":
                    return "Empresas.Numero_interior";
                case "Colonia":
                    return "Empresas.Colonia";
                case "CP":
                    return "Empresas.CP";
                case "Ciudad":
                    return "Empresas.Ciudad";
                case "Estado[Nombre_del_Estado]":
                case "EstadoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Pais[Nombre_del_Pais]":
                case "PaisNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";
                case "Regimen_Fiscal[Descripcion]":
                case "Regimen_FiscalDescripcion":
                    return "Regimenes_Fiscales.Descripcion";
                case "Nombre_o_Razon_Social":
                    return "Empresas.Nombre_o_Razon_Social";
                case "RFC":
                    return "Empresas.RFC";
                case "Calle_Fiscal":
                    return "Empresas.Calle_Fiscal";
                case "Numero_exterior_Fiscal":
                    return "Empresas.Numero_exterior_Fiscal";
                case "Numero_interior_Fiscal":
                    return "Empresas.Numero_interior_Fiscal";
                case "Colonia_Fiscal":
                    return "Empresas.Colonia_Fiscal";
                case "CP_Fiscal":
                    return "Empresas.CP_Fiscal";
                case "Ciudad_Fiscal":
                    return "Empresas.Ciudad_Fiscal";
                case "Estado_Fiscal[Nombre_del_Estado]":
                case "Estado_FiscalNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Pais_Fiscal[Nombre_del_Pais]":
                case "Pais_FiscalNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Telefono_Fiscal":
                    return "Empresas.Telefono_Fiscal";
                case "Fax":
                    return "Empresas.Fax";
                case "Nombres_del_Representante_Legal":
                    return "Empresas.Nombres_del_Representante_Legal";
                case "Apellido_Paterno_del_Representante_Legal":
                    return "Empresas.Apellido_Paterno_del_Representante_Legal";
                case "Apellido_Materno_del_Representante_Legal":
                    return "Empresas.Apellido_Materno_del_Representante_Legal";
                case "Nombre_Completo_del_Representante_Legal":
                    return "Empresas.Nombre_Completo_del_Representante_Legal";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Empresas).GetProperty(columnName));
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

