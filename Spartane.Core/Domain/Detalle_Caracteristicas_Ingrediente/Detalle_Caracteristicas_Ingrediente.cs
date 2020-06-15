using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ingredientes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente
{
    /// <summary>
    /// Detalle_Caracteristicas_Ingrediente table
    /// </summary>
    public class Detalle_Caracteristicas_Ingrediente: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ingrediente { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

        [ForeignKey("Folio_Ingrediente")]
        public virtual Spartane.Core.Domain.Ingredientes.Ingredientes Folio_Ingrediente_Ingredientes { get; set; }

    }
	
	public class Detalle_Caracteristicas_Ingrediente_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Ingrediente { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

		        [ForeignKey("Folio_Ingrediente")]
        public virtual Spartane.Core.Domain.Ingredientes.Ingredientes Folio_Ingrediente_Ingredientes { get; set; }

    }


}

