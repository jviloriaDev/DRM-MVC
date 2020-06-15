using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Aseguradoras
{
    /// <summary>
    /// Aseguradoras table
    /// </summary>
    public class Aseguradoras: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }


    }
	
	public class Aseguradoras_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre { get; set; }

		
    }


}

