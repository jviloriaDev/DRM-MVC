using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios
{
    /// <summary>
    /// Interpretacion_Dificultad_de_Rutina_de_Ejercicios table
    /// </summary>
    public class Interpretacion_Dificultad_de_Rutina_de_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Interpretacion_Dificultad_de_Rutina_de_Ejercicios_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

