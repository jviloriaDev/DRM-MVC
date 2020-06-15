using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MedicosAdvanceSearchModel
    {
        public MedicosAdvanceSearchModel()
        {
            Foto = RadioOptions.NoApply;
            Cedula_Fiscal_Documento = RadioOptions.NoApply;
            Comprobante_de_Domicilio = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Registro { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Registro", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Registro { set; get; }

        public string ToHora_de_Registro { set; get; }
        public string FromHora_de_Registro { set; get; }

        public Filters Usuario_que_RegistraFilter { set; get; }
        public string AdvanceUsuario_que_Registra { set; get; }
        public int[] AdvanceUsuario_que_RegistraMultiple { set; get; }

        public Filters Titulo_PersonalFilter { set; get; }
        public string AdvanceTitulo_Personal { set; get; }
        public int[] AdvanceTitulo_PersonalMultiple { set; get; }

        public Filters NombresFilter { set; get; }
        public string Nombres { set; get; }

        public Filters Apellido_PaternoFilter { set; get; }
        public string Apellido_Paterno { set; get; }

        public Filters Apellido_MaternoFilter { set; get; }
        public string Apellido_Materno { set; get; }

        public Filters Nombre_CompletoFilter { set; get; }
        public string Nombre_Completo { set; get; }

        public Filters Tipo_de_EspecialistaFilter { set; get; }
        public string AdvanceTipo_de_Especialista { set; get; }
        public int[] AdvanceTipo_de_EspecialistaMultiple { set; get; }

        public RadioOptions Foto { set; get; }

        public Filters Nombre_de_usuarioFilter { set; get; }
        public string Nombre_de_usuario { set; get; }

        public Filters Usuario_RegistradoFilter { set; get; }
        public string AdvanceUsuario_Registrado { set; get; }
        public int[] AdvanceUsuario_RegistradoMultiple { set; get; }

        public Filters EmailFilter { set; get; }
        public string Email { set; get; }

        public Filters CelularFilter { set; get; }
        public string Celular { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_nacimiento { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_nacimiento", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_nacimiento { set; get; }

        public Filters Pais_de_nacimientoFilter { set; get; }
        public string AdvancePais_de_nacimiento { set; get; }
        public int[] AdvancePais_de_nacimientoMultiple { set; get; }

        public Filters Entidad_de_nacimientoFilter { set; get; }
        public string AdvanceEntidad_de_nacimiento { set; get; }
        public int[] AdvanceEntidad_de_nacimientoMultiple { set; get; }

        public Filters SexoFilter { set; get; }
        public string AdvanceSexo { set; get; }
        public int[] AdvanceSexoMultiple { set; get; }

        public Filters Email_institucionalFilter { set; get; }
        public string Email_institucional { set; get; }

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }

        public Filters Email_ppal_publicoFilter { set; get; }
        public string AdvanceEmail_ppal_publico { set; get; }
        public int[] AdvanceEmail_ppal_publicoMultiple { set; get; }

        public Filters Email_de_contactoFilter { set; get; }
        public string Email_de_contacto { set; get; }

        public Filters CalleFilter { set; get; }
        public string Calle { set; get; }

        public Filters Numero_exteriorFilter { set; get; }
        public string Numero_exterior { set; get; }

        public Filters Numero_interiorFilter { set; get; }
        public string Numero_interior { set; get; }

        public Filters ColoniaFilter { set; get; }
        public string Colonia { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCP { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCP", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCP { set; get; }

        public Filters CiudadFilter { set; get; }
        public string Ciudad { set; get; }

        public Filters EstadoFilter { set; get; }
        public string AdvanceEstado { set; get; }
        public int[] AdvanceEstadoMultiple { set; get; }

        public Filters PaisFilter { set; get; }
        public string AdvancePais { set; get; }
        public int[] AdvancePaisMultiple { set; get; }

        public Filters TelefonosFilter { set; get; }
        public string Telefonos { set; get; }

        public Filters En_HospitalFilter { set; get; }
        public string AdvanceEn_Hospital { set; get; }
        public int[] AdvanceEn_HospitalMultiple { set; get; }

        public Filters Nombre_del_HospitalFilter { set; get; }
        public string Nombre_del_Hospital { set; get; }

        public Filters Piso_hospitalFilter { set; get; }
        public string Piso_hospital { set; get; }

        public Filters Numero_de_consultorioFilter { set; get; }
        public string Numero_de_consultorio { set; get; }

        public Filters Se_ajusta_tabuladorFilter { set; get; }
        public string AdvanceSe_ajusta_tabulador { set; get; }
        public int[] AdvanceSe_ajusta_tabuladorMultiple { set; get; }

        public Filters ProfesionFilter { set; get; }
        public string AdvanceProfesion { set; get; }
        public int[] AdvanceProfesionMultiple { set; get; }

        public Filters EspecialidadFilter { set; get; }
        public string AdvanceEspecialidad { set; get; }
        public int[] AdvanceEspecialidadMultiple { set; get; }

        public Filters Resumen_ProfesionalFilter { set; get; }
        public string Resumen_Profesional { set; get; }

        public Filters Regimen_FiscalFilter { set; get; }
        public string AdvanceRegimen_Fiscal { set; get; }
        public int[] AdvanceRegimen_FiscalMultiple { set; get; }

        public Filters Nombre_o_Razon_SocialFilter { set; get; }
        public string Nombre_o_Razon_Social { set; get; }

        public Filters RFCFilter { set; get; }
        public string RFC { set; get; }

        public Filters Calle_FiscalFilter { set; get; }
        public string Calle_Fiscal { set; get; }

        public Filters Numero_exterior_FiscalFilter { set; get; }
        public string Numero_exterior_Fiscal { set; get; }

        public Filters Numero_interior_FiscalFilter { set; get; }
        public string Numero_interior_Fiscal { set; get; }

        public Filters Colonia_FiscalFilter { set; get; }
        public string Colonia_Fiscal { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCP_Fiscal { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCP_Fiscal", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCP_Fiscal { set; get; }

        public Filters Ciudad_FiscalFilter { set; get; }
        public string Ciudad_Fiscal { set; get; }

        public Filters Estado_FiscalFilter { set; get; }
        public string AdvanceEstado_Fiscal { set; get; }
        public int[] AdvanceEstado_FiscalMultiple { set; get; }

        public Filters Pais_FiscalFilter { set; get; }
        public string AdvancePais_Fiscal { set; get; }
        public int[] AdvancePais_FiscalMultiple { set; get; }

        public Filters TelefonoFilter { set; get; }
        public string Telefono { set; get; }

        public Filters FaxFilter { set; get; }
        public string Fax { set; get; }

        public RadioOptions Cedula_Fiscal_Documento { set; get; }

        public RadioOptions Comprobante_de_Domicilio { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCalificacion_Red_de_Medicos { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCalificacion_Red_de_Medicos", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCalificacion_Red_de_Medicos { set; get; }

        public Filters BancoFilter { set; get; }
        public string AdvanceBanco { set; get; }
        public int[] AdvanceBancoMultiple { set; get; }

        public Filters CLABE_InterbancariaFilter { set; get; }
        public string CLABE_Interbancaria { set; get; }

        public Filters Numero_de_CuentaFilter { set; get; }
        public string Numero_de_Cuenta { set; get; }

        public Filters Nombre_del_TitularFilter { set; get; }
        public string Nombre_del_Titular { set; get; }


    }
}
