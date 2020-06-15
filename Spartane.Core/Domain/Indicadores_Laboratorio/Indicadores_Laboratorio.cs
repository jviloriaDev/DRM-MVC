using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Indicadores_Laboratorio
{
    /// <summary>
    /// Indicadores_Laboratorio table
    /// </summary>
    public class Indicadores_Laboratorio: BaseEntity
    {
        public int Folio { get; set; }
        public string Indicador { get; set; }
        public string Unidad_de_Medida { get; set; }
        public int? Limite_inferior { get; set; }
        public int? Limite_superior { get; set; }


    }
	
	public class Indicadores_Laboratorio_Datos_Generales
    {
                public int Folio { get; set; }
        public string Indicador { get; set; }
        public string Unidad_de_Medida { get; set; }
        public int? Limite_inferior { get; set; }
        public int? Limite_superior { get; set; }

		
    }


}

