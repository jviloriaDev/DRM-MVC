using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_Information_by_StateModel
    {
        [Required]
        public int Information_by_StateId { get; set; }
        public int? Phase { get; set; }
        public string PhaseName { get; set; }
        public int? State { get; set; }
        public string StateName { get; set; }
        public int? Folder { get; set; }
        public string FolderGroup_Name { get; set; }
        public bool Visible { get; set; }
        public bool Read_Only { get; set; }
        public bool Required { get; set; }
        public string Label { get; set; }

    }
}

