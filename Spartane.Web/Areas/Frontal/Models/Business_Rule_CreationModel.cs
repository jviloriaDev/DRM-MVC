using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Business_Rule_CreationModel
    {
        [Required]
        public int Key_Business_Rule_Creation { get; set; }
        public int? User { get; set; }
        public string UserName { get; set; }
        public string Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        public string Last_Updated_Date { get; set; }
        public string Last_Updated_Hour { get; set; }
        [Range(0, 9999999999)]
        public int? Time_that_took { get; set; }
        public string Name { get; set; }
        public int? Documentation { get; set; }
        public HttpPostedFileBase DocumentationFile { set; get; }
        public int DocumentationRemoveAttachment { set; get; }
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        public int? Complexity { get; set; }
        public string ComplexityDescription { get; set; }

        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string ObjectId { get; set; }
        public string Attribute { get; set; }
        public string Screen { get; set; }

    }
}

