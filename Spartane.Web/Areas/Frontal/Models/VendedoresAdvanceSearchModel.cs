using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class VendedoresAdvanceSearchModel
    {
        public VendedoresAdvanceSearchModel()
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

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }

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
