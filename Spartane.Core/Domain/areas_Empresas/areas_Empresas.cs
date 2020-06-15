using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.areas_Empresas
{
    /// <summary>
    /// areas_Empresas table
    /// </summary>
    public class areas_Empresas: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
	
	public class areas_Empresas_Datos_Generales
    {
                public int Clave { get; set; }
        public string Nombre { get; set; }

		
    }


}

