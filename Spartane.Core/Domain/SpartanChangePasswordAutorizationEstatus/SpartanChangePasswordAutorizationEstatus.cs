using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus
{
    /// <summary>
    /// SpartanChangePasswordAutorizationEstatus table
    /// </summary>
    public class SpartanChangePasswordAutorizationEstatus: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

