using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ProveedoresAdvanceSearchModel
    {
        public ProveedoresAdvanceSearchModel()
        {

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

        public Filters Nombre_del_ProveedorFilter { set; get; }
        public string Nombre_del_Proveedor { set; get; }

        public Filters Tipo_de_ProveedorFilter { set; get; }
        public string AdvanceTipo_de_Proveedor { set; get; }
        public int[] AdvanceTipo_de_ProveedorMultiple { set; get; }

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }

        public Filters NombresFilter { set; get; }
        public string Nombres { set; get; }

        public Filters Apellido_PaternoFilter { set; get; }
        public string Apellido_Paterno { set; get; }

        public Filters Apellido_MaternoFilter { set; get; }
        public string Apellido_Materno { set; get; }

        public Filters Nombre_CompletoFilter { set; get; }
        public string Nombre_Completo { set; get; }

        public Filters Nombre_de_UsuarioFilter { set; get; }
        public string Nombre_de_Usuario { set; get; }

        public Filters Usuario_RegistradoFilter { set; get; }
        public string AdvanceUsuario_Registrado { set; get; }
        public int[] AdvanceUsuario_RegistradoMultiple { set; get; }

        public Filters EmailFilter { set; get; }
        public string Email { set; get; }

        public Filters CelularFilter { set; get; }
        public string Celular { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Nacimiento { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Nacimiento", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Nacimiento { set; get; }

        public Filters Pais_de_nacimientoFilter { set; get; }
        public string AdvancePais_de_nacimiento { set; get; }
        public int[] AdvancePais_de_nacimientoMultiple { set; get; }

        public Filters Entidad_de_nacimientoFilter { set; get; }
        public string AdvanceEntidad_de_nacimiento { set; get; }
        public int[] AdvanceEntidad_de_nacimientoMultiple { set; get; }

        public Filters SexoFilter { set; get; }
        public string AdvanceSexo { set; get; }
        public int[] AdvanceSexoMultiple { set; get; }

        public Filters Regimen_FiscalFilter { set; get; }
        public string AdvanceRegimen_Fiscal { set; get; }
        public int[] AdvanceRegimen_FiscalMultiple { set; get; }

        public Filters Nombre_o_Razon_SocialFilter { set; get; }
        public string Nombre_o_Razon_Social { set; get; }

        public Filters RFCFilter { set; get; }
        public string RFC { set; get; }

        public Filters Calle_FiscalFilter { set; get; }
        public string Calle_Fiscal { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromNumero_exterior_Fiscal { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromNumero_exterior_Fiscal", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToNumero_exterior_Fiscal { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromNumero_interior_Fiscal { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromNumero_interior_Fiscal", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToNumero_interior_Fiscal { set; get; }

        public Filters Colonia_FiscalFilter { set; get; }
        public string Colonia_Fiscal { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromC_P__Fiscal { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromC_P__Fiscal", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToC_P__Fiscal { set; get; }

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


    }
}
