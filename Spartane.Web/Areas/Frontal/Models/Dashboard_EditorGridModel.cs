using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_EditorGridModel
    {
        public int Dashboard_Id { get; set; }
        public string Registration_Date { get; set; }
        public int? Registration_User { get; set; }
        public string Registration_UserName { get; set; }
        public string Name { get; set; }
        public int? Dashboard_Template { get; set; }
        public string Dashboard_TemplateDescription { get; set; }
        public bool? Show_in_Home { get; set; }
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        public int? Spartan_Object { get; set; }
        
    }
}

