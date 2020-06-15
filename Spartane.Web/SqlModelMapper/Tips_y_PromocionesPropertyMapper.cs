using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Tips_y_Promociones;

namespace Spartane.Web.SqlModelMapper
{
    public class Tips_y_PromocionesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Tips_y_Promociones.Folio";
                case "Fecha_de_registro":
                    return "Tips_y_Promociones.Fecha_de_registro";
                case "Hora_de_Registro":
                    return "Tips_y_Promociones.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre":
                    return "Tips_y_Promociones.Nombre";
                case "Descripcion_Corta":
                    return "Tips_y_Promociones.Descripcion_Corta";
                case "Descripcion_Larga":
                    return "Tips_y_Promociones.Descripcion_Larga";
                case "Fecha_inicio_de_Vigencia":
                    return "Tips_y_Promociones.Fecha_inicio_de_Vigencia";
                case "Fecha_fin_de_Vigencia":
                    return "Tips_y_Promociones.Fecha_fin_de_Vigencia";
                case "Especialidad[Especialidad]":
                case "EspecialidadEspecialidad":
                    return "Especialidades.Especialidad";
                case "Especialista[Nombre_Completo]":
                case "EspecialistaNombre_Completo":
                    return "Medicos.Nombre_Completo";
                case "Vendedor[Name]":
                case "VendedorName":
                    return "Spartan_User.Name";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Tips_y_Promociones).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_registro")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_inicio_de_Vigencia")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin_de_Vigencia")
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

