using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Template_Dashboard_EditorMainModel
    {
        public Template_Dashboard_EditorModel Template_Dashboard_EditorInfo { set; get; }
        public Template_Dashboard_DetailGridModelPost Template_Dashboard_DetailGridInfo { set; get; }

    }

    public class Template_Dashboard_DetailGridModelPost
    {
        public int Detail_Id { get; set; }
        public short? Row_Number { get; set; }
        public short? Columns { get; set; }

        public bool Removed { set; get; }
    }



}

