using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Frecuencia_de_pago_Empresas;
using Spartane.Core.Domain.Estatus_de_Suscripcion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Suscripciones_Empresa
{
    /// <summary>
    /// Detalle_Suscripciones_Empresa table
    /// </summary>
    public class Detalle_Suscripciones_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public int? Cantidad_de_Beneficiarios { get; set; }
        public int? Suscripcion { get; set; }
        public DateTime? Fecha_de_inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Frecuencia_de_Pago")]
        public virtual Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas Frecuencia_de_Pago_Frecuencia_de_pago_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion Estatus_Estatus_de_Suscripcion { get; set; }

    }
	
	public class Detalle_Suscripciones_Empresa_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public int? Cantidad_de_Beneficiarios { get; set; }
        public int? Suscripcion { get; set; }
        public DateTime? Fecha_de_inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Frecuencia_de_Pago")]
        public virtual Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas Frecuencia_de_Pago_Frecuencia_de_pago_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Suscripcion.Estatus_de_Suscripcion Estatus_Estatus_de_Suscripcion { get; set; }

    }


}

