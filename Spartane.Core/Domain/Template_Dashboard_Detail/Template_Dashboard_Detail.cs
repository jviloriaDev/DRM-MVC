using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Template_Dashboard_Editor;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Template_Dashboard_Detail
{
    /// <summary>
    /// Template_Dashboard_Detail table
    /// </summary>
    public class Template_Dashboard_Detail: BaseEntity
    {
        public int Detail_Id { get; set; }
        public int? Template { get; set; }
        public short? Row_Number { get; set; }
        public short? Columns { get; set; }

        [ForeignKey("Template")]
        public virtual Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor Template_Template_Dashboard_Editor { get; set; }

    }
	
	public class Template_Dashboard_Detail_Datos_Generales
    {
                public int Detail_Id { get; set; }
        public int? Template { get; set; }
        public short? Row_Number { get; set; }
        public short? Columns { get; set; }

		        [ForeignKey("Template")]
        public virtual Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor Template_Template_Dashboard_Editor { get; set; }

    }


}

