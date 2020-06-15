using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Planes_de_Rutinas;

namespace Spartane.Web.SqlModelMapper
{
    public class Planes_de_RutinasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Planes_de_Rutinas.Folio";
                case "Fecha_de_Registro":
                    return "Planes_de_Rutinas.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Planes_de_Rutinas.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Fecha_inicio_del_Plan":
                    return "Planes_de_Rutinas.Fecha_inicio_del_Plan";
                case "Fecha_fin_del_Plan":
                    return "Planes_de_Rutinas.Fecha_fin_del_Plan";
                case "Semana":
                    return "Planes_de_Rutinas.Semana";
                case "Paciente[Nombre_Completo]":
                case "PacienteNombre_Completo":
                    return "Pacientes.Nombre_Completo";
                case "Rutinas[Nombre_de_la_Rutina]":
                case "RutinasNombre_de_la_Rutina":
                    return "Rutinas.Nombre_de_la_Rutina";
                case "Modificado":
                    return "Planes_de_Rutinas.Modificado";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Planes_de_Rutinas).GetProperty(columnName));
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
            if (columnName == "Fecha_inicio_del_Plan")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin_del_Plan")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Modificado")
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

