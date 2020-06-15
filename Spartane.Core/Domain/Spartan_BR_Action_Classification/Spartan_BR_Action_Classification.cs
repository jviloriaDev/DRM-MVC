using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Action_Classification
{
    /// <summary>
    /// Spartan_BR_Action_Classification table
    /// </summary>
    public class Spartan_BR_Action_Classification: BaseEntity
    {
        public short ClassificationId { get; set; }
        public string Description { get; set; }


    }
}

