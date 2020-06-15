using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Format_Configuration
{
    /// <summary>
    /// Spartan_Format_Configuration table
    /// </summary>
    public class Spartan_Format_Configuration: BaseEntity
    {
        public int? Format { get; set; }
        public string Query_To_Fill_Fields { get; set; }
        public string Filter_to_Show { get; set; }


    }
}

