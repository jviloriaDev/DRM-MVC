using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Traduction_Object_Type
{
    /// <summary>
    /// Spartan_Traduction_Object_Type table
    /// </summary>
    public class Spartan_Traduction_Object_Type: BaseEntity
    {
        public int IdType { get; set; }
        public string Object_Type_Description { get; set; }


    }
}

