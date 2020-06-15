using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EstadoModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_del_Estado { get; set; }
        public int? Folio_Pais { get; set; }
        public string Folio_PaisNombre_del_Pais { get; set; }

    }
	
	public class Estado_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_del_Estado { get; set; }
        public int? Folio_Pais { get; set; }
        public string Folio_PaisNombre_del_Pais { get; set; }

    }


}

