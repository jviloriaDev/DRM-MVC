using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Dashboard_Editor;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Dashboard_Config_Detail
{
    /// <summary>
    /// Dashboard_Config_Detail table
    /// </summary>
    public class Dashboard_Config_Detail: BaseEntity
    {
        public int Detail_Id { get; set; }
        public int? Dashboard { get; set; }
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        public short? ConfigRow { get; set; }
        public short? ConfigColumn { get; set; }

        [ForeignKey("Dashboard")]
        public virtual Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor Dashboard_Dashboard_Editor { get; set; }

    }
	
	public class Dashboard_Config_Detail_Datos_Generales
    {
                public int Detail_Id { get; set; }
        public int? Dashboard { get; set; }
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        public short? ConfigRow { get; set; }
        public short? ConfigColumn { get; set; }

		        [ForeignKey("Dashboard")]
        public virtual Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor Dashboard_Dashboard_Editor { get; set; }

    }


}

