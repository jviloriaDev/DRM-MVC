using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Indicadores_Consultas
{
    /// <summary>
    /// Indicadores_Consultas table
    /// </summary>
    public class Indicadores_Consultas: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
	
	public class Indicadores_Consultas_Datos_Generales
    {
                public int Clave { get; set; }
        public string Nombre { get; set; }

		
    }


}

