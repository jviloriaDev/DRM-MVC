using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas
{
    /// <summary>
    /// Planes_de_Suscripcion_Especialistas table
    /// </summary>
    public class Planes_de_Suscripcion_Especialistas: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Costo { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Planes_de_Suscripcion_Especialistas_Datos_Generales
    {
                public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Costo { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

