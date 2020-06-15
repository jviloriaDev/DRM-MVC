using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Vendedores;

namespace Spartane.Web.SqlModelMapper
{
    public class VendedoresPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Vendedores.Folio";
                case "Fecha_de_Registro":
                    return "Vendedores.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Vendedores.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombres":
                    return "Vendedores.Nombres";
                case "Apellido_Paterno":
                    return "Vendedores.Apellido_Paterno";
                case "Apellido_Materno":
                    return "Vendedores.Apellido_Materno";
                case "Nombre_Completo":
                    return "Vendedores.Nombre_Completo";
                case "Nombre_de_Usuario":
                    return "Vendedores.Nombre_de_Usuario";
                case "Usuario_Registrado[Name]":
                case "Usuario_RegistradoName":
                    return "Spartan_User.Name";
                case "Email":
                    return "Vendedores.Email";
                case "Celular":
                    return "Vendedores.Celular";
                case "Fecha_de_nacimiento":
                    return "Vendedores.Fecha_de_nacimiento";
                case "Pais_de_nacimiento[Nombre_del_Pais]":
                case "Pais_de_nacimientoNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Entidad_de_nacimiento[Nombre_del_Estado]":
                case "Entidad_de_nacimientoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";
                case "Banco[Nombre]":
                case "BancoNombre":
                    return "Bancos.Nombre";
                case "CLABE_Interbancaria":
                    return "Vendedores.CLABE_Interbancaria";
                case "Numero_de_Cuenta":
                    return "Vendedores.Numero_de_Cuenta";
                case "Nombre_del_Titular":
                    return "Vendedores.Nombre_del_Titular";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Vendedores).GetProperty(columnName));
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
            if (columnName == "Fecha_de_nacimiento")
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

