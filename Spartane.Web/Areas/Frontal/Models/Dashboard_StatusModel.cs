using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_StatusModel
    {
        [Required]
        public short Status_Id { get; set; }
        public string Description { get; set; }

    }
	
	public class Dashboard_Status_Datos_GeneralesModel
    {
        [Required]
        public short Status_Id { get; set; }
        public string Description { get; set; }

    }


}

