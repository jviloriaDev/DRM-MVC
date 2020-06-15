using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Traduction_Object
{
    /// <summary>
    /// Spartan_Traduction_Object table
    /// </summary>
    public class Spartan_Traduction_Object: BaseEntity
    {
        public int IdObject { get; set; }
        public string Object_Description { get; set; }
        public int? Object_Type { get; set; }

        [ForeignKey("Object_Type")]
        public virtual Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type Object_Type_Spartan_Traduction_Object_Type { get; set; }

    }
}

