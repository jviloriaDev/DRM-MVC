using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Medicos;

namespace Spartane.Web.SqlModelMapper
{
    public class MedicosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Medicos.Folio";
                case "Fecha_de_Registro":
                    return "Medicos.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Medicos.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Titulo_Personal[Descripcion]":
                case "Titulo_PersonalDescripcion":
                    return "Titulos_Personales.Descripcion";
                case "Nombres":
                    return "Medicos.Nombres";
                case "Apellido_Paterno":
                    return "Medicos.Apellido_Paterno";
                case "Apellido_Materno":
                    return "Medicos.Apellido_Materno";
                case "Nombre_Completo":
                    return "Medicos.Nombre_Completo";
                case "Tipo_de_Especialista[Descripcion]":
                case "Tipo_de_EspecialistaDescripcion":
                    return "Tipos_de_Especialistas.Descripcion";
                case "Nombre_de_usuario":
                    return "Medicos.Nombre_de_usuario";
                case "Usuario_Registrado[Name]":
                case "Usuario_RegistradoName":
                    return "Spartan_User.Name";
                case "Email":
                    return "Medicos.Email";
                case "Celular":
                    return "Medicos.Celular";
                case "Fecha_de_nacimiento":
                    return "Medicos.Fecha_de_nacimiento";
                case "Pais_de_nacimiento[Nombre_del_Pais]":
                case "Pais_de_nacimientoNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Entidad_de_nacimiento[Nombre_del_Estado]":
                case "Entidad_de_nacimientoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Email_institucional":
                    return "Medicos.Email_institucional";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";
                case "Email_ppal_publico[Descripcion]":
                case "Email_ppal_publicoDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Email_de_contacto":
                    return "Medicos.Email_de_contacto";
                case "Calle":
                    return "Medicos.Calle";
                case "Numero_exterior":
                    return "Medicos.Numero_exterior";
                case "Numero_interior":
                    return "Medicos.Numero_interior";
                case "Colonia":
                    return "Medicos.Colonia";
                case "CP":
                    return "Medicos.CP";
                case "Ciudad":
                    return "Medicos.Ciudad";
                case "Estado[Nombre_del_Estado]":
                case "EstadoNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Pais[Nombre_del_Pais]":
                case "PaisNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Telefonos":
                    return "Medicos.Telefonos";
                case "En_Hospital[Descripcion]":
                case "En_HospitalDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Nombre_del_Hospital":
                    return "Medicos.Nombre_del_Hospital";
                case "Piso_hospital":
                    return "Medicos.Piso_hospital";
                case "Numero_de_consultorio":
                    return "Medicos.Numero_de_consultorio";
                case "Se_ajusta_tabulador[Descripcion]":
                case "Se_ajusta_tabuladorDescripcion":
                    return "Respuesta_Logica.Descripcion";
                case "Profesion[Descripcion]":
                case "ProfesionDescripcion":
                    return "Profesiones.Descripcion";
                case "Especialidad[Especialidad]":
                case "EspecialidadEspecialidad":
                    return "Especialidades.Especialidad";
                case "Resumen_Profesional":
                    return "Medicos.Resumen_Profesional";
                case "Regimen_Fiscal[Descripcion]":
                case "Regimen_FiscalDescripcion":
                    return "Regimenes_Fiscales.Descripcion";
                case "Nombre_o_Razon_Social":
                    return "Medicos.Nombre_o_Razon_Social";
                case "RFC":
                    return "Medicos.RFC";
                case "Calle_Fiscal":
                    return "Medicos.Calle_Fiscal";
                case "Numero_exterior_Fiscal":
                    return "Medicos.Numero_exterior_Fiscal";
                case "Numero_interior_Fiscal":
                    return "Medicos.Numero_interior_Fiscal";
                case "Colonia_Fiscal":
                    return "Medicos.Colonia_Fiscal";
                case "CP_Fiscal":
                    return "Medicos.CP_Fiscal";
                case "Ciudad_Fiscal":
                    return "Medicos.Ciudad_Fiscal";
                case "Estado_Fiscal[Nombre_del_Estado]":
                case "Estado_FiscalNombre_del_Estado":
                    return "Estado.Nombre_del_Estado";
                case "Pais_Fiscal[Nombre_del_Pais]":
                case "Pais_FiscalNombre_del_Pais":
                    return "Pais.Nombre_del_Pais";
                case "Telefono":
                    return "Medicos.Telefono";
                case "Fax":
                    return "Medicos.Fax";
                case "Calificacion_Red_de_Medicos":
                    return "Medicos.Calificacion_Red_de_Medicos";
                case "Banco[Nombre]":
                case "BancoNombre":
                    return "Bancos.Nombre";
                case "CLABE_Interbancaria":
                    return "Medicos.CLABE_Interbancaria";
                case "Numero_de_Cuenta":
                    return "Medicos.Numero_de_Cuenta";
                case "Nombre_del_Titular":
                    return "Medicos.Nombre_del_Titular";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Medicos).GetProperty(columnName));
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

