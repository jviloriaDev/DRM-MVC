using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Estatus_Reservaciones_Actividad
{
    /// <summary>
    /// Estatus_Reservaciones_Actividad table
    /// </summary>
    public class Estatus_Reservaciones_Actividad: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Estatus_Reservaciones_Actividad_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

