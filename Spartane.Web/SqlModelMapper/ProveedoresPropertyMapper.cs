using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Proveedores;

namespace Spartane.Web.SqlModelMapper
{
    public class ProveedoresPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Proveedores.Folio";
                case "Fecha_de_Registro":
                    return "Proveedores.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Proveedores.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre_del_Proveedor":
                    return "Proveedores.Nombre_del_Proveedor";
                case "Tipo_de_Proveedor[Descripcion]":
                case "Tipo_de_ProveedorDescripcion":
                    return "Tipo_de_proveedor.Descripcion";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";
                case "Nombres":
                    return "Proveedores.Nombres";
                case "Apellido_Paterno":
                    return "Proveedores.Apellido_Paterno";
                case "Apellido_Materno":
                    return "Proveedores.Apellido_Materno";
                case "Nombre_Completo":
                    return "Proveedores.Nombre_Completo";
                case "Nombre_de_Usuario":
                    return "Proveedores.Nombre_de_Usuario";
                case "Usuario_Registrado[Name]":
                case "Usuario_RegistradoName":
                    return "Spartan_User.Name";
                case "Email":
                    return "Proveedores.Email";
                case "Celular":
                    return "Proveedores.Celular";
                case "Fecha_de_Nacimiento":
                    return "Proveedores.Fecha_de_Nacimiento";
                case "Pais_de_nacimiento[Nombre_del_Pais]":
                case "Pais_de_nacimientoNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Entidad_de_nacimiento[Nombre_del_Estado]":
                case "Entidad_de_nacimientoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Regimen_Fiscal[Descripcion]":
                case "Regimen_FiscalDescripcion":
                    return "Regimenes_Fiscales.Descripcion";
                case "Nombre_o_Razon_Social":
                    return "Proveedores.Nombre_o_Razon_Social";
                case "RFC":
                    return "Proveedores.RFC";
                case "Calle_Fiscal":
                    return "Proveedores.Calle_Fiscal";
                case "Numero_exterior_Fiscal":
                    return "Proveedores.Numero_exterior_Fiscal";
                case "Numero_interior_Fiscal":
                    return "Proveedores.Numero_interior_Fiscal";
                case "Colonia_Fiscal":
                    return "Proveedores.Colonia_Fiscal";
                case "C_P__Fiscal":
                    return "Proveedores.C_P__Fiscal";
                case "Ciudad_Fiscal":
                    return "Proveedores.Ciudad_Fiscal";
                case "Estado_Fiscal[Nombre_del_Estado]":
                case "Estado_FiscalNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Pais_Fiscal[Nombre_del_Pais]":
                case "Pais_FiscalNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Telefono":
                    return "Proveedores.Telefono";
                case "Fax":
                    return "Proveedores.Fax";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Proveedores).GetProperty(columnName));
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
            if (columnName == "Fecha_de_Nacimiento")
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

