using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Asuntos_Asistencia_Telefonica
{
    /// <summary>
    /// Asuntos_Asistencia_Telefonica table
    /// </summary>
    public class Asuntos_Asistencia_Telefonica: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Asuntos_Asistencia_Telefonica_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }

		
    }


}

