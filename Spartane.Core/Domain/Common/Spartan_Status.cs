using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Common
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public abstract class Spartan_Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
