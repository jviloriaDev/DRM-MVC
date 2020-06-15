using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.SpartanObject
{
    /// <summary>
    /// SpartanObject table
    /// </summary>
    public class SpartanObject: BaseEntity
    {
        public int Object_Id { get; set; }
        public string Name { get; set; }


    }
}

