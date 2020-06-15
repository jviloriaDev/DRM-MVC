using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Registro_en_Evento;
using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Spartan_User;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento
{
    /// <summary>
    /// Detalle_Consulta_Actividades_Registro_Evento table
    /// </summary>
    public class Detalle_Consulta_Actividades_Registro_Evento: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Registro_Evento { get; set; }
        public int? Actividad { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public int? Especialidad { get; set; }
        public int? Imparte { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Lugares_disponibles { get; set; }
        public string Horarios_disponibles { get; set; }
        public string Ubicacion { get; set; }

        [ForeignKey("Folio_Registro_Evento")]
        public virtual Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento Folio_Registro_Evento_Registro_en_Evento { get; set; }
        [ForeignKey("Actividad")]
        public virtual Spartane.Core.Domain.Detalle_Actividades_Evento.Detalle_Actividades_Evento Actividad_Detalle_Actividades_Evento { get; set; }
        [ForeignKey("Tipo_de_Actividad")]
        public virtual Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades Tipo_de_Actividad_Tipos_de_Actividades { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Domain.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Imparte")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Imparte_Spartan_User { get; set; }

    }
	
	public class Detalle_Consulta_Actividades_Registro_Evento_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Registro_Evento { get; set; }
        public int? Actividad { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public int? Especialidad { get; set; }
        public int? Imparte { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Lugares_disponibles { get; set; }
        public string Horarios_disponibles { get; set; }
        public string Ubicacion { get; set; }

		        [ForeignKey("Folio_Registro_Evento")]
        public virtual Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento Folio_Registro_Evento_Registro_en_Evento { get; set; }
        [ForeignKey("Actividad")]
        public virtual Spartane.Core.Domain.Detalle_Actividades_Evento.Detalle_Actividades_Evento Actividad_Detalle_Actividades_Evento { get; set; }
        [ForeignKey("Tipo_de_Actividad")]
        public virtual Spartane.Core.Domain.Tipos_de_Actividades.Tipos_de_Actividades Tipo_de_Actividad_Tipos_de_Actividades { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Domain.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Imparte")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Imparte_Spartan_User { get; set; }

    }


}

