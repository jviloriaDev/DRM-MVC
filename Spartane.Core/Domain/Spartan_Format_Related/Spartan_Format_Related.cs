using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Format;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Format_Related
{
    /// <summary>
    /// Spartan_Format_Related table
    /// </summary>
    public class Spartan_Format_Related: BaseEntity
    {
        public int Clave { get; set; }
        public int? FormatId { get; set; }
        public int? FormatId_Related { get; set; }
        public short? Order { get; set; }

        [ForeignKey("FormatId")]
        public virtual Spartane.Core.Domain.Spartan_Format.Spartan_Format FormatId_Spartan_Format { get; set; }
        [ForeignKey("FormatId_Related")]
        public virtual Spartane.Core.Domain.Spartan_Format.Spartan_Format FormatId_Related_Spartan_Format { get; set; }

    }
}

