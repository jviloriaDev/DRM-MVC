using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_EditorModel
    {
        [Required]
        public int Dashboard_Id { get; set; }
        public string Registration_Date { get; set; }
        public int? Registration_User { get; set; }
        public string Registration_UserName { get; set; }
        public string Name { get; set; }
        public int? Dashboard_Template { get; set; }
        public string Dashboard_TemplateDescription { get; set; }
        public bool Show_in_Home { get; set; }
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        [Range(0, 9999999999)]
        public int? Spartan_Object { get; set; }

    }
	
	public class Dashboard_Editor_Datos_GeneralesModel
    {
        [Required]
        public int Dashboard_Id { get; set; }
        public string Registration_Date { get; set; }
        public int? Registration_User { get; set; }
        public string Registration_UserName { get; set; }
        public string Name { get; set; }
        public int? Dashboard_Template { get; set; }
        public string Dashboard_TemplateDescription { get; set; }
        public bool? Show_in_Home { get; set; }
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        [Range(0, 9999999999)]
        public int? Spartan_Object { get; set; }

    }

	public class Dashboard_Editor_ConfiguracionModel
    {
        [Required]
        public int Dashboard_Id { get; set; }

    }


}

