using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores
{
    /// <summary>
    /// Planes_de_Suscripcion_Proveedores table
    /// </summary>
    public class Planes_de_Suscripcion_Proveedores: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Planes_de_Suscripcion_Proveedores_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }

		
    }


}

