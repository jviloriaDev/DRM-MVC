using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Eventos;

namespace Spartane.Web.SqlModelMapper
{
    public class EventosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Eventos.Folio";
                case "Fecha_de_Registro":
                    return "Eventos.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Eventos.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Empresa[Nombre_de_la_Empresa]":
                case "EmpresaNombre_de_la_Empresa":
                    return "Empresas.Nombre_de_la_Empresa";
                case "Nombre_del_Evento":
                    return "Eventos.Nombre_del_Evento";
                case "Descripcion":
                    return "Eventos.Descripcion";
                case "Fecha_inicio_del_Evento":
                    return "Eventos.Fecha_inicio_del_Evento";
                case "Fecha_fin_del_Evento":
                    return "Eventos.Fecha_fin_del_Evento";
                case "Cantidad_de_dias":
                    return "Eventos.Cantidad_de_dias";
                case "Evento_en_Empresa[Descripcion]":
                case "Evento_en_EmpresaDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Nombre_del_Lugar":
                    return "Eventos.Nombre_del_Lugar";
                case "Calle":
                    return "Eventos.Calle";
                case "Numero_exterior":
                    return "Eventos.Numero_exterior";
                case "Numero_interior":
                    return "Eventos.Numero_interior";
                case "Colonia":
                    return "Eventos.Colonia";
                case "CP":
                    return "Eventos.CP";
                case "Ciudad":
                    return "Eventos.Ciudad";
                case "Estado[Nombre_del_Estado]":
                case "EstadoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Pais[Nombre_del_Pais]":
                case "PaisNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Permite_Familiares[Descripcion]":
                case "Permite_FamiliaresDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_Eventos.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Eventos).GetProperty(columnName));
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
            if (columnName == "Fecha_inicio_del_Evento")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin_del_Evento")
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

