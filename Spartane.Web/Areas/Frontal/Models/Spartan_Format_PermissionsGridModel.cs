using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_PermissionsGridModel
    {
        public int PermissionId { get; set; }
        public int? Format { get; set; }
        public string FormatFormat_Name { get; set; }
        public short? Permission_Type { get; set; }
        public string Permission_TypeDescription { get; set; }
        public bool? Apply { get; set; }
        public int? Spartan_User_Role { get; set; }
        
    }
}

