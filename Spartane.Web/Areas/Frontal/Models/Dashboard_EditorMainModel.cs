using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_EditorMainModel
    {
        public Dashboard_EditorModel Dashboard_EditorInfo { set; get; }
        public Dashboard_Config_DetailGridModelPost Dashboard_Config_DetailGridInfo { set; get; }

    }

    public class Dashboard_Config_DetailGridModelPost
    {
        public int Detail_Id { get; set; }
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        public short? ConfigRow { get; set; }
        public short? ConfigColumn { get; set; }

        public bool Removed { set; get; }
    }



}

