using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Process_Event
{
    /// <summary>
    /// Spartan_BR_Process_Event table
    /// </summary>
    public class Spartan_BR_Process_Event: BaseEntity
    {
        public short ProcessEventId { get; set; }
        public string Description { get; set; }


    }
}

