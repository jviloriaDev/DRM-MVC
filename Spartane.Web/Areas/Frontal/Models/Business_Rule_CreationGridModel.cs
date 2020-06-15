using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Business_Rule_CreationGridModel
    {
        public int Key_Business_Rule_Creation { get; set; }
        public int? User { get; set; }
        public string UserName { get; set; }
        public string Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        public string Last_Updated_Date { get; set; }
        public string Last_Updated_Hour { get; set; }
        public int? Time_that_took { get; set; }
        public string Name { get; set; }
        public int? Documentation { get; set; } //FileInfo
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        public int? Complexity { get; set; }
        public string ComplexityDescription { get; set; }
        
    }
}

