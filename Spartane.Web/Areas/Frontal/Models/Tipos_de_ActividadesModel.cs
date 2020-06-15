using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tipos_de_ActividadesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }

    }
	
	public class Tipos_de_Actividades_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }

    }


}

