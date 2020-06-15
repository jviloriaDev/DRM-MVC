using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Padecimientos;
using Spartane.Core.Domain.Parentesco;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Antecedentes_Familiares
{
    /// <summary>
    /// Detalle_Antecedentes_Familiares table
    /// </summary>
    public class Detalle_Antecedentes_Familiares: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Enfermedad { get; set; }
        public int? Parentesco { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Enfermedad")]
        public virtual Spartane.Core.Domain.Padecimientos.Padecimientos Enfermedad_Padecimientos { get; set; }
        [ForeignKey("Parentesco")]
        public virtual Spartane.Core.Domain.Parentesco.Parentesco Parentesco_Parentesco { get; set; }

    }
	
	public class Detalle_Antecedentes_Familiares_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Enfermedad { get; set; }
        public int? Parentesco { get; set; }

		        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Enfermedad")]
        public virtual Spartane.Core.Domain.Padecimientos.Padecimientos Enfermedad_Padecimientos { get; set; }
        [ForeignKey("Parentesco")]
        public virtual Spartane.Core.Domain.Parentesco.Parentesco Parentesco_Parentesco { get; set; }

    }


}

