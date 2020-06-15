using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Estatus_Paciente;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Especialistas_Pacientes
{
    /// <summary>
    /// Detalle_Especialistas_Pacientes table
    /// </summary>
    public class Detalle_Especialistas_Pacientes: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Especialista { get; set; }
        public int? Especialidad { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Cantidad_consultas { get; set; }
        public bool? Principal { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Especialista_Spartan_User { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Domain.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente Estatus_Estatus_Paciente { get; set; }

    }
	
	public class Detalle_Especialistas_Pacientes_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Especialista { get; set; }
        public int? Especialidad { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Cantidad_consultas { get; set; }
        public bool? Principal { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Especialista_Spartan_User { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Domain.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente Estatus_Estatus_Paciente { get; set; }

    }


}

