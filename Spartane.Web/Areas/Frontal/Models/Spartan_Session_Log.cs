using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Session_Log
    {
        public int Session_Log_Id { get; set; }

        public int? Security_Log_Id { get; set; }

        public DateTime? Log_Date { get; set; }

        public int? User_Role_Id { get; set; }

        public int? User_Id { get; set; }

        public string IP_Address_Source { get; set; }

        public string IP_Address_Target { get; set; }

        public string Computer_Name { get; set; }

        public short? Language_Id { get; set; }

        public string URL { get; set; }

        public short? Event_Type { get; set; }

        public short? Result_Id { get; set; }

        public short? Event_Type2 { get; set; }
    }
}