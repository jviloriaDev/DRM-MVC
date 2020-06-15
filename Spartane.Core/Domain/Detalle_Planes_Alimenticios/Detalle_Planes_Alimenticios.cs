using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Planes_Alimenticios;
using Spartane.Core.Domain.Tiempos_de_Comida;
using Spartane.Core.Domain.Dias_de_la_semana;
using Spartane.Core.Domain.Platillos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Planes_Alimenticios
{
    /// <summary>
    /// Detalle_Planes_Alimenticios table
    /// </summary>
    public class Detalle_Planes_Alimenticios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Planes_Alimenticios { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public int? Numero_de_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Platillo { get; set; }
        public bool? Modificado { get; set; }

        [ForeignKey("Folio_Planes_Alimenticios")]
        public virtual Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios Folio_Planes_Alimenticios_Planes_Alimenticios { get; set; }
        [ForeignKey("Tiempo_de_Comida")]
        public virtual Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida Tiempo_de_Comida_Tiempos_de_Comida { get; set; }
        [ForeignKey("Numero_de_Dia")]
        public virtual Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana Numero_de_Dia_Dias_de_la_semana { get; set; }
        [ForeignKey("Platillo")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Platillo_Platillos { get; set; }

    }
	
	public class Detalle_Planes_Alimenticios_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Planes_Alimenticios { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public int? Numero_de_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Platillo { get; set; }
        public bool? Modificado { get; set; }

		        [ForeignKey("Folio_Planes_Alimenticios")]
        public virtual Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios Folio_Planes_Alimenticios_Planes_Alimenticios { get; set; }
        [ForeignKey("Tiempo_de_Comida")]
        public virtual Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida Tiempo_de_Comida_Tiempos_de_Comida { get; set; }
        [ForeignKey("Numero_de_Dia")]
        public virtual Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana Numero_de_Dia_Dias_de_la_semana { get; set; }
        [ForeignKey("Platillo")]
        public virtual Spartane.Core.Domain.Platillos.Platillos Platillo_Platillos { get; set; }

    }


}

