using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Platillos;

namespace Spartane.Web.SqlModelMapper
{
    public class PlatillosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Platillos.Folio";
                case "Fecha_de_Registro":
                    return "Platillos.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Platillos.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre_de_Platillo":
                    return "Platillos.Nombre_de_Platillo";
                case "Calorias[Cantidad]":
                case "CaloriasCantidad":
                    return "Calorias.Cantidad";
                case "Dificultad[Categoria]":
                case "DificultadCategoria":
                    return "Dificultad_de_platillos.Categoria";
                case "Categoria_del_Platillo[Categoria]":
                case "Categoria_del_PlatilloCategoria":
                    return "Categorias_de_platillos.Categoria";
                case "Tiempo_de_comida[Comida]":
                case "Tiempo_de_comidaComida":
                    return "Tiempos_de_Comida.Comida";
                case "Tipo_de_comida[Tipo_de_comida]":
                case "Tipo_de_comidaTipo_de_comida":
                    return "Tipo_de_comida_platillos.Tipo_de_comida";
                case "Caracteristicas[Caracteristicas]":
                case "CaracteristicasCaracteristicas":
                    return "Caracteristicas_platillo.Caracteristicas";
                case "Calificacion":
                    return "Platillos.Calificacion";
                case "Modo_de_Preparacion":
                    return "Platillos.Modo_de_Preparacion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Platillos).GetProperty(columnName));
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

