using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Sustancias;
using Spartane.Core.Domain.Frecuencia_Sustancias;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos
{
    /// <summary>
    /// Detalle_Antecedentes_No_Patologicos table
    /// </summary>
    public class Detalle_Antecedentes_No_Patologicos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Sustancia { get; set; }
        public int? Frecuencia { get; set; }
        public int? Cantidad { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Sustancia")]
        public virtual Spartane.Core.Domain.Sustancias.Sustancias Sustancia_Sustancias { get; set; }
        [ForeignKey("Frecuencia")]
        public virtual Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias Frecuencia_Frecuencia_Sustancias { get; set; }

    }
	
	public class Detalle_Antecedentes_No_Patologicos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Sustancia { get; set; }
        public int? Frecuencia { get; set; }
        public int? Cantidad { get; set; }

		        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Sustancia")]
        public virtual Spartane.Core.Domain.Sustancias.Sustancias Sustancia_Sustancias { get; set; }
        [ForeignKey("Frecuencia")]
        public virtual Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias Frecuencia_Frecuencia_Sustancias { get; set; }

    }


}

