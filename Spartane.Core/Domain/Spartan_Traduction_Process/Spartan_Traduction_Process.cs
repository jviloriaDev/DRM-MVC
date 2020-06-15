using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Traduction_Language;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;
using Spartane.Core.Domain.SpartanObject;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Traduction_Process
{
    /// <summary>
    /// Spartan_Traduction_Process table
    /// </summary>
    public class Spartan_Traduction_Process: BaseEntity
    {
        public int IdTraduction { get; set; }
        public int? LanguageT { get; set; }
        public int? Object_Type { get; set; }
        public int? ObjectT { get; set; }

        [ForeignKey("LanguageT")]
        public virtual Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language LanguageT_Spartan_Traduction_Language { get; set; }
        [ForeignKey("Object_Type")]
        public virtual Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type Object_Type_Spartan_Traduction_Object_Type { get; set; }
        [ForeignKey("ObjectT")]
        public virtual Spartane.Core.Domain.SpartanObject.SpartanObject ObjectT_SpartanObject { get; set; }

    }
}

