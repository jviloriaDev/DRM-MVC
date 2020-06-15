using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_User_Status
{
    /// <summary>
    /// Spartan_User_Status table
    /// </summary>
    public class Spartan_User_Status: BaseEntity
    {
        public int User_Status_Id { get; set; }
        public string Description { get; set; }


    }
}

