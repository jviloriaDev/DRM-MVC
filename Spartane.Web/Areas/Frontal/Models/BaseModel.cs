using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class BaseModel
    {
        public int CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int? DeletedBy { get; set; }

        public string DeletedOn { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }

        public string LoginDate { get; set; }

        public string UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
    }

    public class Grid_File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] File { get; set; }
        public bool RemoveFile { set; get; }
        public HttpPostedFileBase Control { set; get; }
    }
}