using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion
{
    /// <summary>
    /// Tipo_de_Plan_de_Suscripcion table
    /// </summary>
    public class Tipo_de_Plan_de_Suscripcion: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
	
	public class Tipo_de_Plan_de_Suscripcion_Datos_Generales
    {
                public int Clave { get; set; }
        public string Nombre { get; set; }

		
    }


}

