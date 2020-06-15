using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_FormatGridModel
    {
        public int FormatId { get; set; }
        public string Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? Registration_User { get; set; }
        public String Registration_UserName { get; set; }
        public string Format_Name { get; set; }
        public short? Format_Type { get; set; }
        public string Format_TypeDescription { get; set; }
        public string Search { get; set; }
        public int? Object { get; set; }
        public string ObjectName { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        
    }
}

