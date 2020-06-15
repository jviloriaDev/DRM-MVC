using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Bitacora_SQLAdvanceSearchModel
    {
        public Spartan_Bitacora_SQLAdvanceSearchModel()
        {
            Result = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromId_User { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromId_User", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToId_User { set; get; }

        public Filters Type_SQLFilter { set; get; }
        public string Type_SQL { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromRegister_Date { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromRegister_Date", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToRegister_Date { set; get; }

        public Filters Computer_NameFilter { set; get; }
        public string Computer_Name { set; get; }

        public Filters Server_NameFilter { set; get; }
        public string Server_Name { set; get; }

        public Filters Database_NameFilter { set; get; }
        public string Database_Name { set; get; }

        public Filters System_NameFilter { set; get; }
        public string System_Name { set; get; }

        public Filters System_VersionFilter { set; get; }
        public string System_Version { set; get; }

        public Filters Windows_VersionFilter { set; get; }
        public string Windows_Version { set; get; }

        public Filters Command_SQLFilter { set; get; }
        public string Command_SQL { set; get; }

        public Filters Folio_SQLFilter { set; get; }
        public string Folio_SQL { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromObject_Id { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromObject_Id", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToObject_Id { set; get; }

        public Filters IPFilter { set; get; }
        public string IP { set; get; }

        public Filters JsonFilter { set; get; }
        public string Json { set; get; }

        public RadioOptions Result { set; get; }

        public Filters ErrorFilter { set; get; }
        public string Error { set; get; }


    }
}
