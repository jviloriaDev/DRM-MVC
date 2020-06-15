using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartaneUserRoleModule
{
    public class CustomDataHolder
    {
        
        public string Data { get; set; }
        public int ModuleID { get; set; }
        public int UserRoleID { get; set; }
        public string[] childrens { get; set; }
        public int order { get; set; }

        public int User_Rule_Module_Object_Id { get; set; }
        public int Module_Object_Id { get; set; }
        public int ObjectID { get; set; }
        public string Checked { get; set; }
        public string functionChecked { get; set; }

        public int ObjectType { get; set; }
        public string ObjectTypeDescription { get; set; }
        public string NewEditDisabled { get; set; }

        public int ParentObjectId { get; set; }
    }
}
