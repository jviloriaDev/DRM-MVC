using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Security
{
    public class Spartan_Module
    {
        public Spartan_Module()
        {
            this.Children = new List<Spartan_Module>();
        }

        public int ModuleId { get; set; }
        public string Nombre { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public bool HasChildren { get; set; }
        public bool Expanded
        {
            get
            {
                return this.HasChildren;
            }
        }
        public IList<Spartan_Module> Children { get; set; }
    }
}
