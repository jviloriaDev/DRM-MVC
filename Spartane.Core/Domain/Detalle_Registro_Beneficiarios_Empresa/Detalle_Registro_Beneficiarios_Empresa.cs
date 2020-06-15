using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Empresa
{
    /// <summary>
    /// Detalle_Registro_Beneficiarios_Empresa table
    /// </summary>
    public class Detalle_Registro_Beneficiarios_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresa_Empresas { get; set; }
        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Detalle_Registro_Beneficiarios_Empresa_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresa_Empresas { get; set; }
        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Domain.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

