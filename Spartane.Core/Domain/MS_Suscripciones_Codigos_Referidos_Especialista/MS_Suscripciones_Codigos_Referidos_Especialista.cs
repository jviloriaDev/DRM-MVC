using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Codigos_Referidos;
using Spartane.Core.Domain.Planes_de_Suscripcion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista
{
    /// <summary>
    /// MS_Suscripciones_Codigos_Referidos_Especialista table
    /// </summary>
    public class MS_Suscripciones_Codigos_Referidos_Especialista: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Codigos { get; set; }
        public int? Plan_de_Suscripcion { get; set; }

        [ForeignKey("Folio_Codigos")]
        public virtual Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos Folio_Codigos_Detalle_Codigos_Referidos { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Plan_de_Suscripcion_Planes_de_Suscripcion { get; set; }

    }
	
	public class MS_Suscripciones_Codigos_Referidos_Especialista_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Codigos { get; set; }
        public int? Plan_de_Suscripcion { get; set; }

		        [ForeignKey("Folio_Codigos")]
        public virtual Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos Folio_Codigos_Detalle_Codigos_Referidos { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Plan_de_Suscripcion_Planes_de_Suscripcion { get; set; }

    }


}

