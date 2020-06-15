using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Ubicaciones_Eventos_Empresa
{
    /// <summary>
    /// Ubicaciones_Eventos_Empresa table
    /// </summary>
    public class Ubicaciones_Eventos_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Cupo { get; set; }
        public int? Ubicacion_externa { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public int? Empresa { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Ubicacion_externa")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Ubicacion_externa_Respuesta_Logica { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Ubicaciones_Eventos_Empresa_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Cupo { get; set; }
        public int? Ubicacion_externa { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public int? Empresa { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Ubicacion_externa")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Ubicacion_externa_Respuesta_Logica { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

