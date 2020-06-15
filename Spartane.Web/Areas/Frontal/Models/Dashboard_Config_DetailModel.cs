using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_Config_DetailModel
    {
        [Required]
        public int Detail_Id { get; set; }
        [Range(0, 9999999999)]
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        [Range(0, 9999999999)]
        public short? ConfigRow { get; set; }
        [Range(0, 9999999999)]
        public short? ConfigColumn { get; set; }

    }
	
	public class Dashboard_Config_Detail_Datos_GeneralesModel
    {
        [Required]
        public int Detail_Id { get; set; }
        [Range(0, 9999999999)]
        public int? Report_Id { get; set; }
        public string Report_Name { get; set; }
        [Range(0, 9999999999)]
        public short? ConfigRow { get; set; }
        [Range(0, 9999999999)]
        public short? ConfigColumn { get; set; }

    }


}

