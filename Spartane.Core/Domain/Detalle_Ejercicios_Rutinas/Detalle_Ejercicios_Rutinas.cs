using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Rutinas;
using Spartane.Core.Domain.Ejercicios;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Ejercicios_Rutinas
{
    /// <summary>
    /// Detalle_Ejercicios_Rutinas table
    /// </summary>
    public class Detalle_Ejercicios_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Rutinas { get; set; }
        public int? Orden_de_realizacion { get; set; }
        public int? Numero_de_serie { get; set; }
        public int? Ejercicio { get; set; }
        public int? Cantidad_de_Repeticiones { get; set; }

        [ForeignKey("Folio_Rutinas")]
        public virtual Spartane.Core.Domain.Rutinas.Rutinas Folio_Rutinas_Rutinas { get; set; }
        [ForeignKey("Ejercicio")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Ejercicio_Ejercicios { get; set; }

    }
	
	public class Detalle_Ejercicios_Rutinas_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Rutinas { get; set; }
        public int? Orden_de_realizacion { get; set; }
        public int? Numero_de_serie { get; set; }
        public int? Ejercicio { get; set; }
        public int? Cantidad_de_Repeticiones { get; set; }

		        [ForeignKey("Folio_Rutinas")]
        public virtual Spartane.Core.Domain.Rutinas.Rutinas Folio_Rutinas_Rutinas { get; set; }
        [ForeignKey("Ejercicio")]
        public virtual Spartane.Core.Domain.Ejercicios.Ejercicios Ejercicio_Ejercicios { get; set; }

    }


}

