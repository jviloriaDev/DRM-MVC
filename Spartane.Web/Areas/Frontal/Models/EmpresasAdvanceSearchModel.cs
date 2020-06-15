using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EmpresasAdvanceSearchModel
    {
        public EmpresasAdvanceSearchModel()
        {
            Cedula_Fiscal = RadioOptions.NoApply;

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

        public Filters Nombre_de_la_EmpresaFilter { set; get; }
        public string Nombre_de_la_Empresa { set; get; }

        public Filters Tipo_de_EmpresaFilter { set; get; }
        public string AdvanceTipo_de_Empresa { set; get; }
        public int[] AdvanceTipo_de_EmpresaMultiple { set; get; }

        public Filters EmailFilter { set; get; }
        public string Email { set; get; }

        public Filters TelefonoFilter { set; get; }
        public string Telefono { set; get; }

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

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }

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

        public Filters Telefono_FiscalFilter { set; get; }
        public string Telefono_Fiscal { set; get; }

        public Filters FaxFilter { set; get; }
        public string Fax { set; get; }

        public Filters Nombres_del_Representante_LegalFilter { set; get; }
        public string Nombres_del_Representante_Legal { set; get; }

        public Filters Apellido_Paterno_del_Representante_LegalFilter { set; get; }
        public string Apellido_Paterno_del_Representante_Legal { set; get; }

        public Filters Apellido_Materno_del_Representante_LegalFilter { set; get; }
        public string Apellido_Materno_del_Representante_Legal { set; get; }

        public Filters Nombre_Completo_del_Representante_LegalFilter { set; get; }
        public string Nombre_Completo_del_Representante_Legal { set; get; }

        public RadioOptions Cedula_Fiscal { set; get; }


    }
}
