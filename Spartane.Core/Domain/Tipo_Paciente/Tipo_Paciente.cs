using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_Paciente
{
    /// <summary>
    /// Tipo_Paciente table
    /// </summary>
    public class Tipo_Paciente: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Clave_Rol { get; set; }


    }
	
	public class Tipo_Paciente_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Clave_Rol { get; set; }

		
    }


}

