using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_proveedor;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Regimenes_Fiscales;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Proveedores
{
    /// <summary>
    /// Proveedores table
    /// </summary>
    public class Proveedores: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_del_Proveedor { get; set; }
        public int? Tipo_de_Proveedor { get; set; }
        public int? Estatus { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_de_Usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_Nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public int? Numero_exterior_Fiscal { get; set; }
        public int? Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        public int? C_P__Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Proveedor")]
        public virtual Spartane.Core.Domain.Tipo_de_proveedor.Tipo_de_proveedor Tipo_de_Proveedor_Tipo_de_proveedor { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Entidad_de_nacimiento")]
        public virtual Spartane.Core.Domain.Estado.Estado Entidad_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Regimen_Fiscal")]
        public virtual Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales Regimen_Fiscal_Regimenes_Fiscales { get; set; }
        [ForeignKey("Estado_Fiscal")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Fiscal_Estado { get; set; }
        [ForeignKey("Pais_Fiscal")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Fiscal_Pais { get; set; }

    }
	
	public class Proveedores_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_del_Proveedor { get; set; }
        public int? Tipo_de_Proveedor { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Proveedor")]
        public virtual Spartane.Core.Domain.Tipo_de_proveedor.Tipo_de_proveedor Tipo_de_Proveedor_Tipo_de_proveedor { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }

	public class Proveedores_Datos_de_Contacto
    {
                public int Folio { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_de_Usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_Nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public int? Sexo { get; set; }

		        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Entidad_de_nacimiento")]
        public virtual Spartane.Core.Domain.Estado.Estado Entidad_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }

    }

	public class Proveedores_Red_de_Proveedores
    {
                public int Folio { get; set; }

		
    }

	public class Proveedores_Datos_Fiscales
    {
                public int Folio { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public int? Numero_exterior_Fiscal { get; set; }
        public int? Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        public int? C_P__Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }

		        [ForeignKey("Regimen_Fiscal")]
        public virtual Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales Regimen_Fiscal_Regimenes_Fiscales { get; set; }
        [ForeignKey("Estado_Fiscal")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Fiscal_Estado { get; set; }
        [ForeignKey("Pais_Fiscal")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Fiscal_Pais { get; set; }

    }


}

