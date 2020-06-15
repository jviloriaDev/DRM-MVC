using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class AseguradorasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }

    }
	
	public class Aseguradoras_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }

    }


}

