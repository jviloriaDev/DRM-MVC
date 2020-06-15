using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Template_Dashboard_Editor
{
    /// <summary>
    /// Template_Dashboard_Editor table
    /// </summary>
    public class Template_Dashboard_Editor: BaseEntity
    {
        public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }
        public string Path { get; set; }

        [ForeignKey("Template_Image_Thumbnail")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Template_Image_Thumbnail_Spartane_File { get; set; }

    }
	
	public class Template_Dashboard_Editor_Datos_Generales
    {
                public int Template_Id { get; set; }
        public string Description { get; set; }
        public int? Template_Image_Thumbnail { get; set; }
        public string Template_Image_Thumbnail_URL { get; set; }

		        [ForeignKey("Template_Image_Thumbnail")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Template_Image_Thumbnail_Spartane_File { get; set; }

    }


}

