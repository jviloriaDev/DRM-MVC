using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Core.Domain.Musculos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.MS_Musculos
{
    /// <summary>
    /// MS_Musculos table
    /// </summary>
    public class MS_Musculos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Musculo { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Musculo")]
        public virtual Spartane.Core.Domain.Musculos.Musculos Musculo_Musculos { get; set; }

    }
	
	public class MS_Musculos_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Musculo { get; set; }

		        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Musculo")]
        public virtual Spartane.Core.Domain.Musculos.Musculos Musculo_Musculos { get; set; }

    }


}

