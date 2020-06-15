using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pais;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tiempos_de_Comida
{
    /// <summary>
    /// Tiempos_de_Comida table
    /// </summary>
    public class Tiempos_de_Comida: BaseEntity
    {
        public int Clave { get; set; }
        public string Comida { get; set; }
        public string Hora_min { get; set; }
        public string Hora_max { get; set; }
        public int? Pais { get; set; }

        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }

    }
	
	public class Tiempos_de_Comida_Datos_Generales
    {
                public int Clave { get; set; }
        public string Comida { get; set; }
        public string Hora_min { get; set; }
        public string Hora_max { get; set; }
        public int? Pais { get; set; }

		        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }

    }


}

