using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Proveedores;
using Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Estatus_de_Suscripcion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
{
    /// <summary>
    /// Detalle_Suscripcion_Red_de_Especialistas_Proveedores table
    /// </summary>
    public class Detalle_Suscripcion_Red_de_Especialistas_Proveedores: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Proveedores { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        //public string Contrato_URL { get; set; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Proveedores")]
        public virtual Spartane.Core.Domain.Proveedores.Proveedores Folio_Proveedores_Proveedores { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores { get; set; }
        [ForeignKey("Contrato")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Contrato_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion Estatus_Estatus_de_Suscripcion { get; set; }

    }
	
	public class Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Proveedores { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public string Contrato_URL { get; set; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Proveedores")]
        public virtual Spartane.Core.Domain.Proveedores.Proveedores Folio_Proveedores_Proveedores { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores { get; set; }
        [ForeignKey("Contrato")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Contrato_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion Estatus_Estatus_de_Suscripcion { get; set; }

    }


}

