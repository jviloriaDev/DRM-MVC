using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Template_Dashboard_EditorGridModel
    {
        public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }
        public Grid_File Template_Image_ThumbnailFileInfo { set; get; }
        
    }
}

