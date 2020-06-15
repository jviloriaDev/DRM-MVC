using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Pantalla_Francisco
{
    /// <summary>
    /// Pantalla_Francisco table
    /// </summary>
    public class Pantalla_Francisco: BaseEntity
    {
        public int Folio { get; set; }
        public string Campo { get; set; }


    }
	
	public class Pantalla_Francisco_Datos_Generales
    {
                public int Folio { get; set; }
        public string Campo { get; set; }

		
    }


}

