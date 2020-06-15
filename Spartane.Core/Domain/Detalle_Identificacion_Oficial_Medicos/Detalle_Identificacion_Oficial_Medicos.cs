using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Identificaciones_Oficiales;
using Spartane.Core.Domain.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos
{
    /// <summary>
    /// Detalle_Identificacion_Oficial_Medicos table
    /// </summary>
    public class Detalle_Identificacion_Oficial_Medicos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Medico { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public int? Documento { get; set; }
        //public string Documento_URL { get; set; }

        [ForeignKey("Folio_Medico")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Medico_Medicos { get; set; }
        [ForeignKey("Tipo_de_Identificacion_Oficial")]
        public virtual Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales { get; set; }
        [ForeignKey("Documento")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Documento_Spartane_File { get; set; }

    }
	
	public class Detalle_Identificacion_Oficial_Medicos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Medico { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public int? Documento { get; set; }
        public string Documento_URL { get; set; }

		        [ForeignKey("Folio_Medico")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Medico_Medicos { get; set; }
        [ForeignKey("Tipo_de_Identificacion_Oficial")]
        public virtual Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales Tipo_de_Identificacion_Oficial_Identificaciones_Oficiales { get; set; }
        [ForeignKey("Documento")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Documento_Spartane_File { get; set; }

    }


}

