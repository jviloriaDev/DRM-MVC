using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Dashboard_Status
{
    /// <summary>
    /// Dashboard_Status table
    /// </summary>
    public class Dashboard_Status: BaseEntity
    {
        public short Status_Id { get; set; }
        public string Description { get; set; }


    }
	
	public class Dashboard_Status_Datos_Generales
    {
                public short Status_Id { get; set; }
        public string Description { get; set; }

		
    }


}

