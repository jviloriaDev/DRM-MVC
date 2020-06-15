using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Especialistas_Pacientes;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Especialistas_PacientesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Especialistas_Pacientes.Folio";
                case "Especialista[Name]":
                case "EspecialistaName":
                    return "Spartan_User.Name";
                case "Especialidad[Especialidad]":
                case "EspecialidadEspecialidad":
                    return "Especialidades.Especialidad";
                case "Fecha_inicio":
                    return "Detalle_Especialistas_Pacientes.Fecha_inicio";
                case "Fecha_fin":
                    return "Detalle_Especialistas_Pacientes.Fecha_fin";
                case "Cantidad_consultas":
                    return "Detalle_Especialistas_Pacientes.Cantidad_consultas";
                case "Principal":
                    return "Detalle_Especialistas_Pacientes.Principal";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_Paciente.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Especialistas_Pacientes).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_inicio")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Principal")
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

