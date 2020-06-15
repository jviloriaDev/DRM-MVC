using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Dificultad_de_platillos
{
    /// <summary>
    /// Dificultad_de_platillos table
    /// </summary>
    public class Dificultad_de_platillos: BaseEntity
    {
        public int Clave { get; set; }
        public string Categoria { get; set; }


    }
	
	public class Dificultad_de_platillos_Datos_Generales
    {
                public int Clave { get; set; }
        public string Categoria { get; set; }

		
    }


}

