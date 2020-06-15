using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Object
{
    /// <summary>
    /// Spartan_Object table
    /// </summary>
    public class Spartan_Object: BaseEntity
    {
        public object Image_Spartan_File { get; set; }
        public object Object_Type_Spartan_Object_Type { get; set; }
        public object Status_Spartan_Object_Status { get; set; }
        public int Object_Id { get; set; }
        public string Name { get; set; }
        public object Image { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int? Object_Type { get; set; }
        public int? Status { get; set; }
        public int Id { get; set; }


    }
}

