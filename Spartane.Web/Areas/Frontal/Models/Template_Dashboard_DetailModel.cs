using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Template_Dashboard_DetailModel
    {
        [Required]
        public int Detail_Id { get; set; }
        [Range(0, 9999999999)]
        public short? Row_Number { get; set; }
        [Range(0, 9999999999)]
        public short? Columns { get; set; }

    }
	
	public class Template_Dashboard_Detail_Datos_GeneralesModel
    {
        [Required]
        public int Detail_Id { get; set; }
        [Range(0, 9999999999)]
        public short? Row_Number { get; set; }
        [Range(0, 9999999999)]
        public short? Columns { get; set; }

    }


}

