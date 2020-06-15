using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PrintReport
    {
        public DataTable Data { get; set; }
        public string Report_Name { get; set; }
    }
}