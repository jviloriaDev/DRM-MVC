using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Nivel_de_Intensidad
{
    /// <summary>
    /// Nivel_de_Intensidad table
    /// </summary>
    public class Nivel_de_Intensidad: BaseEntity
    {
        public int Folio { get; set; }
        public string Intensidad { get; set; }


    }
	
	public class Nivel_de_Intensidad_Datos_Generales
    {
                public int Folio { get; set; }
        public string Intensidad { get; set; }

		
    }


}

