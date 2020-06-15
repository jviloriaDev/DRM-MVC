using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Codigos_Referidos
{
    /// <summary>
    /// Detalle_Codigos_Referidos table
    /// </summary>
    public class Detalle_Codigos_Referidos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Medicos { get; set; }
        public int? Suscripcion { get; set; }
        public int? Porcentaje_de_descuento { get; set; }
        public DateTime? Fecha_inicio_vigencia { get; set; }
        public DateTime? Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_Referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Medicos")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Medicos_Medicos { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Usuario_que_autoriza")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_autoriza_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Detalle_Codigos_Referidos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Medicos { get; set; }
        public int? Suscripcion { get; set; }
        public int? Porcentaje_de_descuento { get; set; }
        public DateTime? Fecha_inicio_vigencia { get; set; }
        public DateTime? Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_Referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Medicos")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Medicos_Medicos { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Usuario_que_autoriza")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_autoriza_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

