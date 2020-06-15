using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Bitacora_SQLModel
    {
        [Required]
        public int Folio { get; set; }
        [Range(0, 9999999999)]
        public int? Id_User { get; set; }
        public string Type_SQL { get; set; }
        public string Register_Date { get; set; }
        public string Computer_Name { get; set; }
        public string Server_Name { get; set; }
        public string Database_Name { get; set; }
        public string System_Name { get; set; }
        public string System_Version { get; set; }
        public string Windows_Version { get; set; }
        public string Command_SQL { get; set; }
        public string Folio_SQL { get; set; }
        [Range(0, 9999999999)]
        public int? Object_Id { get; set; }
        public string IP { get; set; }
        public string Json { get; set; }
        public bool Result { get; set; }
        public string Error { get; set; }

    }
}

