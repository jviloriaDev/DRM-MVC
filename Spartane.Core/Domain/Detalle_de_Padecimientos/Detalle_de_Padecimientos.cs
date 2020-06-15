using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Padecimientos;
using Spartane.Core.Domain.Tiempo_Padecimiento;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estatus_Padecimiento;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_de_Padecimientos
{
    /// <summary>
    /// Detalle_de_Padecimientos table
    /// </summary>
    public class Detalle_de_Padecimientos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Padecimiento { get; set; }
        public int? Tiempo_con_el_diagnostico { get; set; }
        public int? Intervencion_quirurgica { get; set; }
        public string Tratamiento { get; set; }
        public int? Estado_actual { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Padecimiento")]
        public virtual Spartane.Core.Domain.Padecimientos.Padecimientos Padecimiento_Padecimientos { get; set; }
        [ForeignKey("Tiempo_con_el_diagnostico")]
        public virtual Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento Tiempo_con_el_diagnostico_Tiempo_Padecimiento { get; set; }
        [ForeignKey("Intervencion_quirurgica")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Intervencion_quirurgica_Respuesta_Logica { get; set; }
        [ForeignKey("Estado_actual")]
        public virtual Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento Estado_actual_Estatus_Padecimiento { get; set; }

    }
	
	public class Detalle_de_Padecimientos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Padecimiento { get; set; }
        public int? Tiempo_con_el_diagnostico { get; set; }
        public int? Intervencion_quirurgica { get; set; }
        public string Tratamiento { get; set; }
        public int? Estado_actual { get; set; }

		        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Padecimiento")]
        public virtual Spartane.Core.Domain.Padecimientos.Padecimientos Padecimiento_Padecimientos { get; set; }
        [ForeignKey("Tiempo_con_el_diagnostico")]
        public virtual Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento Tiempo_con_el_diagnostico_Tiempo_Padecimiento { get; set; }
        [ForeignKey("Intervencion_quirurgica")]
        public virtual Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica Intervencion_quirurgica_Respuesta_Logica { get; set; }
        [ForeignKey("Estado_actual")]
        public virtual Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento Estado_actual_Estatus_Padecimiento { get; set; }

    }


}

