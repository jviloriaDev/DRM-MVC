using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Unidades_de_MedidaAdvanceSearchModel
    {
        public Unidades_de_MedidaAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromClave { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromClave", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToClave { set; get; }

        public Filters UnidadFilter { set; get; }
        public string Unidad { set; get; }

        public Filters AbreviacionFilter { set; get; }
        public string Abreviacion { set; get; }

        public Filters Texto_SingularFilter { set; get; }
        public string Texto_Singular { set; get; }

        public Filters Texto_PluralFilter { set; get; }
        public string Texto_Plural { set; get; }


    }
}
