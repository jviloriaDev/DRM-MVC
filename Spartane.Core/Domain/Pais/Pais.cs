using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Pais
{
    /// <summary>
    /// Pais table
    /// </summary>
    public class Pais: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_del_Pais { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }


    }
	
	public class Pais_Datos_Generales
    {
                public int Clave { get; set; }
        public string Nombre_del_Pais { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }

		
    }


}

