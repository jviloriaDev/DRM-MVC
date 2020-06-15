using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Cantidad_fraccion_platillos
{
    /// <summary>
    /// Cantidad_fraccion_platillos table
    /// </summary>
    public class Cantidad_fraccion_platillos: BaseEntity
    {
        public int Folio { get; set; }
        public string Cantidad { get; set; }


    }
	
	public class Cantidad_fraccion_platillos_Datos_Generales
    {
                public int Folio { get; set; }
        public string Cantidad { get; set; }

		
    }


}

