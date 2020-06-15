using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlowGridModel
    {
        public int WorkFlowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        public int? Object { get; set; }
        public string ObjectName { get; set; }
        
    }
}

