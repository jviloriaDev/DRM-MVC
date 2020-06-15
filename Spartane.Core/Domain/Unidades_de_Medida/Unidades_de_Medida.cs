using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Unidades_de_Medida
{
    /// <summary>
    /// Unidades_de_Medida table
    /// </summary>
    public class Unidades_de_Medida: BaseEntity
    {
        public int Clave { get; set; }
        public string Unidad { get; set; }
        public string Abreviacion { get; set; }
        public string Texto_Singular { get; set; }
        public string Texto_Plural { get; set; }


    }
	
	public class Unidades_de_Medida_Datos_Generales
    {
                public int Clave { get; set; }
        public string Unidad { get; set; }
        public string Abreviacion { get; set; }
        public string Texto_Singular { get; set; }
        public string Texto_Plural { get; set; }

		
    }


}

