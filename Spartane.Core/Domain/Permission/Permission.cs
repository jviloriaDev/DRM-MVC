using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Permission
{
    public class Permission
    {
        public bool Consult { set; get; }
        public bool New { set; get; }
        public bool Edit { set; get; }
        public bool Delete { set; get; }
        public bool Export { set; get; }
        public bool Print { set; get; }
        public bool Configure { set; get; }
        public int Module { get; set; }
        public int Object { get; set; }
        public int Role { get; set; }

        public Permission()
        {
            Consult = false;
            New = false;
            Edit = false;
            Delete = false;
            Export = false;
            Print = false;
            Configure = false;
        }
    }
}
