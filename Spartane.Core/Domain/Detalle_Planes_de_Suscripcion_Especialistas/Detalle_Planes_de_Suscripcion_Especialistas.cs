using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Domain.Frecuencia_de_pago_Especialistas;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Estatus_de_Suscripcion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas
{
    /// <summary>
    /// Detalle_Planes_de_Suscripcion_Especialistas table
    /// </summary>
    public class Detalle_Planes_de_Suscripcion_Especialistas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public DateTime? Fecha_de_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        //public string Contrato_URL { get; set; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas { get; set; }
        [ForeignKey("Frecuencia_de_Pago")]
        public virtual Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas { get; set; }
        [ForeignKey("Contrato")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Contrato_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion Estatus_Estatus_de_Suscripcion { get; set; }

    }
	
	public class Detalle_Planes_de_Suscripcion_Especialistas_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public DateTime? Fecha_de_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public string Contrato_URL { get; set; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Plan_de_Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas { get; set; }
        [ForeignKey("Frecuencia_de_Pago")]
        public virtual Spartane.Core.Domain.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas { get; set; }
        [ForeignKey("Contrato")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Contrato_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion Estatus_Estatus_de_Suscripcion { get; set; }

    }


}

