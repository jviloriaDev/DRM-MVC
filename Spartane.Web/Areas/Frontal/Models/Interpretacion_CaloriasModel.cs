using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Interpretacion_CaloriasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }

    }
	
	public class Interpretacion_Calorias_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }

    }


}

