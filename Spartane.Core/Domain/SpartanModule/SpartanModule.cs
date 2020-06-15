using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartanModule
{
    public class SpartanModule
    {
        public object Image_Spartan_File { get; set; }
        public object Object_Config_Id_Spartan_Object_Config { get; set; }
        public object Status_Spartan_Module_Status { get; set; }
        public object System_Id_Spartan_System { get; set; }
        public int Module_Id { get; set; }
        public string Name { get; set; }
        public int System_Id { get; set; }
        public int? Parent_Module { get; set; }
        public int Order_Shown { get; set; }
        public object Image { get; set; }
        public object Object_Config_Id { get; set; }
        public object Description { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
    }
}
