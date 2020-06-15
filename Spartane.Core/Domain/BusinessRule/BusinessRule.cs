using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.BusinessRule
{
    public partial class BusinessRule : BaseEntity
    {
        public int IdProcess { get; set; }
        public int IdRule { get; set; }
        public string RuleReturn { get; set; }
    }
}
