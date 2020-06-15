using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo
{
    /// <summary>
    /// Interpretacion_Frecuencia_cardiaca_en_Esfuerzo table
    /// </summary>
    public class Interpretacion_Frecuencia_cardiaca_en_Esfuerzo: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Interpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

