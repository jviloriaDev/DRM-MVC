using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estatus_Eventos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Eventos
{
    /// <summary>
    /// Eventos table
    /// </summary>
    public class Eventos: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Empresa { get; set; }
        public string Nombre_del_Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_inicio_del_Evento { get; set; }
        public DateTime? Fecha_fin_del_Evento { get; set; }
        public int? Cantidad_de_dias { get; set; }
        public int? Evento_en_Empresa { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public int? Pais { get; set; }
        public int? Permite_Familiares { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Evento_en_Empresa")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Evento_en_Empresa_Respuesta_Logica { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Permite_Familiares")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Permite_Familiares_Respuesta_Logica { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos Estatus_Estatus_Eventos { get; set; }

    }
	
	public class Eventos_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Empresa { get; set; }
        public string Nombre_del_Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_inicio_del_Evento { get; set; }
        public DateTime? Fecha_fin_del_Evento { get; set; }
        public int? Cantidad_de_dias { get; set; }
        public int? Evento_en_Empresa { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public int? Pais { get; set; }
        public int? Permite_Familiares { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Empresa")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Empresa_Empresas { get; set; }
        [ForeignKey("Evento_en_Empresa")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Evento_en_Empresa_Respuesta_Logica { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Permite_Familiares")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Permite_Familiares_Respuesta_Logica { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos Estatus_Estatus_Eventos { get; set; }

    }

	public class Eventos_Actividades
    {
                public int Folio { get; set; }

		
    }


}

