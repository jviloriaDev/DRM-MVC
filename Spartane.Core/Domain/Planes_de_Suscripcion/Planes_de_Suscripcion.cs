using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Planes_de_Suscripcion
{
    /// <summary>
    /// Planes_de_Suscripcion table
    /// </summary>
    public class Planes_de_Suscripcion: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Tipo_de_Beneficiario { get; set; }
        public string Nombre { get; set; }
        public string Nombre_del_Plan { get; set; }
        public int? Duracion_en_meses { get; set; }
        public int? Duracion { get; set; }
        public int? Dietas_por_mes { get; set; }
        public int? Rutinas_por_mes { get; set; }
        public decimal? Costo_mensual { get; set; }
        public decimal? Precio_Final { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Beneficiario")]
        public virtual Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion Tipo_de_Beneficiario_Tipo_de_Plan_de_Suscripcion { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Planes_de_Suscripcion_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Tipo_de_Beneficiario { get; set; }
        public string Nombre { get; set; }
        public string Nombre_del_Plan { get; set; }
        public int? Duracion_en_meses { get; set; }
        public int? Duracion { get; set; }
        public int? Dietas_por_mes { get; set; }
        public int? Rutinas_por_mes { get; set; }
        public decimal? Costo_mensual { get; set; }
        public decimal? Precio_Final { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Beneficiario")]
        public virtual Spartane.Core.Domain.Tipo_de_Plan_de_Suscripcion.Tipo_de_Plan_de_Suscripcion Tipo_de_Beneficiario_Tipo_de_Plan_de_Suscripcion { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

