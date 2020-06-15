using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Calorias
{
    /// <summary>
    /// Calorias table
    /// </summary>
    public class Calorias: BaseEntity
    {
        public int Clave { get; set; }
        public string Cantidad { get; set; }


    }
	
	public class Calorias_Datos_Generales
    {
                public int Clave { get; set; }
        public string Cantidad { get; set; }

		
    }


}

