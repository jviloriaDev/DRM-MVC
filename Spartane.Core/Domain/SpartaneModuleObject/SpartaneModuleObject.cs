using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spartane.Core.Domain.SpartaneModuleObject
{
    public class SpartaneModuleObject
    {
        public object Module_Id_Spartan_Module { get; set; }
        public object Object_Id_Spartan_Object { get; set; }
        public int Module_Object_Id { get; set; }
        public int Object_Id { get; set; }
        public int Module_Id { get; set; }
        public string Name { get; set; }
        public string Physical_Name { get; set; }
        public string URL { get; set; }
        public int Order_Shown { get; set; }
        public int Id { get; set; }
        public Int16 Object_Type { get; set; } 
    }
}
