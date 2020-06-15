using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Attribute_Type
{
    /// <summary>
    /// Spartan_Attribute_Type table
    /// </summary>
    public class Spartan_Attribute_Type: BaseEntity
    {
        public int Attribute_Type_Id { get; set; }
        public string Description { get; set; }


    }
}

