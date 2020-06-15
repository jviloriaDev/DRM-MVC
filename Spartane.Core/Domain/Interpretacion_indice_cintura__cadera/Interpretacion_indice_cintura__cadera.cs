using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Interpretacion_indice_cintura__cadera
{
    /// <summary>
    /// Interpretacion_indice_cintura__cadera table
    /// </summary>
    public class Interpretacion_indice_cintura__cadera: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Interpretacion_indice_cintura__cadera_Datos_Generales
    {
                public int Folio { get; set; }
        public string Descripcion { get; set; }

		
    }


}

