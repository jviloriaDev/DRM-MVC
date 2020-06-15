using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Core.Domain.Equipamiento_para_Ejercicios;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Equipamiento_para_Ejercicios
{
    /// <summary>
    /// MS_Equipamiento_para_Ejercicios table
    /// </summary>
    public class MS_Equipamiento_para_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Equipamento { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Equipamento")]
        public virtual Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios Equipamento_Equipamiento_para_Ejercicios { get; set; }

    }
	
	public class MS_Equipamiento_para_Ejercicios_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Equipamento { get; set; }

		        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Equipamento")]
        public virtual Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios Equipamento_Equipamiento_para_Ejercicios { get; set; }

    }


}

