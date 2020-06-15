using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Formas_de_Pago;
using Spartane.Core.Domain.Estatus_de_Pago;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Pagos_Empresa
{
    /// <summary>
    /// Detalle_Pagos_Empresa table
    /// </summary>
    public class Detalle_Pagos_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public int? Suscripcion { get; set; }
        public string Concepto_de_Pago { get; set; }
        public DateTime? Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }
        public DateTime? Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Forma_de_Pago")]
        public virtual Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago Forma_de_Pago_Formas_de_Pago { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago Estatus_Estatus_de_Pago { get; set; }

    }
	
	public class Detalle_Pagos_Empresa_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public int? Suscripcion { get; set; }
        public string Concepto_de_Pago { get; set; }
        public DateTime? Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }
        public DateTime? Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public DateTime? Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Forma_de_Pago")]
        public virtual Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago Forma_de_Pago_Formas_de_Pago { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago Estatus_Estatus_de_Pago { get; set; }

    }


}

