using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ejercicios;

namespace Spartane.Web.SqlModelMapper
{
    public class EjerciciosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Ejercicios.Clave";
                case "Fecha_de_Registro":
                    return "Ejercicios.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Ejercicios.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre_del_Ejercicio":
                    return "Ejercicios.Nombre_del_Ejercicio";
                case "Descripcion_del_Ejercicio":
                    return "Ejercicios.Descripcion_del_Ejercicio";
                case "Tipo_de_Ejercicio[Descripcion]":
                case "Tipo_de_EjercicioDescripcion":
                    return "Tipo_Ejercicio.Descripcion";
                case "Nivel_de_dificultad[Dificultad]":
                case "Nivel_de_dificultadDificultad":
                    return "Nivel_de_dificultad.Dificultad";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Musculos_trabajados":
                    return "Ejercicios.Musculos_trabajados";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Ejercicios).GetProperty(columnName));
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

