using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Common
{
    public class Spartan_Object
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public Spartan_Object_Status Status { get; set; }
        public Spartan_File Image { get; set; }
        public string Url { get; set; }
    }
}
