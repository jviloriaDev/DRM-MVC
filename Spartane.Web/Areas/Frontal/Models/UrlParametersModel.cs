using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class UrlParametersModel
    {
        public int sEcho { get; set; }
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string where { get; set; }
        public string order { get; set; }
        public string filters { get; set; }
        public bool AdvanceSearch { get; set; }
        public string sortDirection { get; set; }
        public string sortColumn { get; set; }
        public List<aColumns> columns { get; set; }
    }

    public class aColumns
    {
        public string data { get; set; }
        public string name { get; set; }
    }
}