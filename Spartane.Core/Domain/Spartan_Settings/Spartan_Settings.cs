using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Settings
{
    /// <summary>
    /// Spartan_Settings table
    /// </summary>
    public class Spartan_Settings: BaseEntity
    {
        public string Clave { get; set; }
        public string Valor { get; set; }


    }
}

