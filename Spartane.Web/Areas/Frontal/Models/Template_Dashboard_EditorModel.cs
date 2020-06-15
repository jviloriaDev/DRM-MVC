using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Template_Dashboard_EditorModel
    {
        [Required]
        public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }
        public HttpPostedFileBase Template_Image_ThumbnailFile { set; get; }
        public int Template_Image_ThumbnailRemoveAttachment { set; get; }

    }
	
	public class Template_Dashboard_Editor_Datos_GeneralesModel
    {
        [Required]
        public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }
        public HttpPostedFileBase Template_Image_ThumbnailFile { set; get; }
        public int Template_Image_ThumbnailRemoveAttachment { set; get; }

    }


}

