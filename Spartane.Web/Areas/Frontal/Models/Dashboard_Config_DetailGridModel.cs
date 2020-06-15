using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_Config_DetailGridModel
    {
        public int Detail_Id { get; set; }
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        public short? ConfigRow { get; set; }
        public short? ConfigColumn { get; set; }
        
    }
}

