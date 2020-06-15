using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal
{
    /// <summary>
    /// Interpretacion_de_porcentaje_de_grasa_corporal table
    /// </summary>
    public class Interpretacion_de_porcentaje_de_grasa_corporal: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Interpretacion_de_porcentaje_de_grasa_corporal_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

