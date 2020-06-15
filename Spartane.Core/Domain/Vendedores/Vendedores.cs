using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Bancos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Vendedores
{
    /// <summary>
    /// Vendedores table
    /// </summary>
    public class Vendedores: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_de_Usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Estatus { get; set; }
        public int? Banco { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Numero_de_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Entidad_de_nacimiento")]
        public virtual Spartane.Core.Domain.Estado.Estado Entidad_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Banco")]
        public virtual Spartane.Core.Domain.Bancos.Bancos Banco_Bancos { get; set; }

    }
	
	public class Vendedores_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_de_Usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Entidad_de_nacimiento")]
        public virtual Spartane.Core.Domain.Estado.Estado Entidad_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }

	public class Vendedores_Codigos_de_Referencia
    {
                public int Folio { get; set; }

		
    }

	public class Vendedores_Datos_Bancarios
    {
                public int Folio { get; set; }
        public int? Banco { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Numero_de_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }

		        [ForeignKey("Banco")]
        public virtual Spartane.Core.Domain.Bancos.Bancos Banco_Bancos { get; set; }

    }

	public class Vendedores_Facturacion
    {
                public int Folio { get; set; }

		
    }


}

