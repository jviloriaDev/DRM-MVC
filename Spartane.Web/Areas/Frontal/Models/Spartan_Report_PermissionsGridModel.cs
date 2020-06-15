using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_PermissionsGridModel
    {
        public int ReportPermissionId { get; set; }
        public int? User_Role { get; set; }
        public int? Report { get; set; }
        public string ReportReport_Name { get; set; }
        public short? Permission_Type { get; set; }
        public string Permission_TypeDescription { get; set; }
        
    }
}

