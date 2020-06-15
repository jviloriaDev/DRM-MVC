using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Planes_de_Rutinas;
using Spartane.Core.Domain.Dias_de_la_semana;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Planes_de_Rutinas
{
    /// <summary>
    /// Detalle_Planes_de_Rutinas table
    /// </summary>
    public class Detalle_Planes_de_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Planes_de_Rutinas { get; set; }
        public int? Numero_de_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? Realizado { get; set; }

        [ForeignKey("Folio_Planes_de_Rutinas")]
        public virtual Spartane.Core.Domain.Planes_de_Rutinas.Planes_de_Rutinas Folio_Planes_de_Rutinas_Planes_de_Rutinas { get; set; }
        [ForeignKey("Numero_de_Dia")]
        public virtual Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana Numero_de_Dia_Dias_de_la_semana { get; set; }

    }
	
	public class Detalle_Planes_de_Rutinas_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Planes_de_Rutinas { get; set; }
        public int? Numero_de_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? Realizado { get; set; }

		        [ForeignKey("Folio_Planes_de_Rutinas")]
        public virtual Spartane.Core.Domain.Planes_de_Rutinas.Planes_de_Rutinas Folio_Planes_de_Rutinas_Planes_de_Rutinas { get; set; }
        [ForeignKey("Numero_de_Dia")]
        public virtual Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana Numero_de_Dia_Dias_de_la_semana { get; set; }

    }


}

