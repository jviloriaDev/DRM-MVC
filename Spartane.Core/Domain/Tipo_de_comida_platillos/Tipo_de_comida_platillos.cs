using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_comida_platillos
{
    /// <summary>
    /// Tipo_de_comida_platillos table
    /// </summary>
    public class Tipo_de_comida_platillos: BaseEntity
    {
        public int Folio { get; set; }
        public string Tipo_de_comida { get; set; }


    }
	
	public class Tipo_de_comida_platillos_Datos_Generales
    {
                public int Folio { get; set; }
        public string Tipo_de_comida { get; set; }

		
    }


}

