using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Redes_sociales
{
    /// <summary>
    /// Redes_sociales table
    /// </summary>
    public class Redes_sociales: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Direccion_URL { get; set; }


    }
	
	public class Redes_sociales_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Direccion_URL { get; set; }

		
    }


}

