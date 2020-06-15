using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Template_Dashboard_Editor;
using Spartane.Core.Domain.Dashboard_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Dashboard_Editor
{
    /// <summary>
    /// Dashboard_Editor table
    /// </summary>
    public class Dashboard_Editor: BaseEntity
    {
        public int Dashboard_Id { get; set; }
        public DateTime? Registration_Date { get; set; }
        public int? Registration_User { get; set; }
        public string Name { get; set; }
        public int? Dashboard_Template { get; set; }
        public bool? Show_in_Home { get; set; }
        public short? Status { get; set; }
        public int? Spartan_Object { get; set; }

        [ForeignKey("Registration_User")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Registration_User_Spartan_User { get; set; }
        [ForeignKey("Dashboard_Template")]
        public virtual Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor Dashboard_Template_Template_Dashboard_Editor { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Dashboard_Status.Dashboard_Status Status_Dashboard_Status { get; set; }

    }
	
	public class Dashboard_Editor_Datos_Generales
    {
                public int Dashboard_Id { get; set; }
        public DateTime? Registration_Date { get; set; }
        public int? Registration_User { get; set; }
        public string Name { get; set; }
        public int? Dashboard_Template { get; set; }
        public bool? Show_in_Home { get; set; }
        public short? Status { get; set; }
        public int? Spartan_Object { get; set; }

		        [ForeignKey("Registration_User")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Registration_User_Spartan_User { get; set; }
        [ForeignKey("Dashboard_Template")]
        public virtual Spartane.Core.Domain.Template_Dashboard_Editor.Template_Dashboard_Editor Dashboard_Template_Template_Dashboard_Editor { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Dashboard_Status.Dashboard_Status Status_Dashboard_Status { get; set; }

    }

	public class Dashboard_Editor_Configuracion
    {
                public int Dashboard_Id { get; set; }

		
    }


}

