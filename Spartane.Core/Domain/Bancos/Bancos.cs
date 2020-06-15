using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Bancos
{
    /// <summary>
    /// Bancos table
    /// </summary>
    public class Bancos: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Completo { get; set; }
        public string Codigo { get; set; }


    }
	
	public class Bancos_Datos_Generales
    {
                public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Completo { get; set; }
        public string Codigo { get; set; }

		
    }


}

