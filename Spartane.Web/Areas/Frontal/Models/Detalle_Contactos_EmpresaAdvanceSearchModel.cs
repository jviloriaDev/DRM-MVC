using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Contactos_EmpresaAdvanceSearchModel
    {
        public Detalle_Contactos_EmpresaAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        public Filters Nombre_completoFilter { set; get; }
        public string Nombre_completo { set; get; }

        public Filters CorreoFilter { set; get; }
        public string Correo { set; get; }

        public Filters TelefonoFilter { set; get; }
        public string Telefono { set; get; }

        public Filters Contacto_PrincipalFilter { set; get; }
        public string AdvanceContacto_Principal { set; get; }
        public int[] AdvanceContacto_PrincipalMultiple { set; get; }

        public Filters AreaFilter { set; get; }
        public string AdvanceArea { set; get; }
        public int[] AdvanceAreaMultiple { set; get; }

        public Filters Acceso_al_SistemaFilter { set; get; }
        public string AdvanceAcceso_al_Sistema { set; get; }
        public int[] AdvanceAcceso_al_SistemaMultiple { set; get; }

        public Filters Nombre_de_usuarioFilter { set; get; }
        public string Nombre_de_usuario { set; get; }

        public Filters Recibe_AlertasFilter { set; get; }
        public string AdvanceRecibe_Alertas { set; get; }
        public int[] AdvanceRecibe_AlertasMultiple { set; get; }

        public Filters EstatusFilter { set; get; }
        public string AdvanceEstatus { set; get; }
        public int[] AdvanceEstatusMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio_Empresas { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio_Empresas", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio_Empresas { set; get; }


    }
}
