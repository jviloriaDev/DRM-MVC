using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Terapia_HormonalModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public string Dosis { get; set; }

    }
	
	public class Detalle_Terapia_Hormonal_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public string Dosis { get; set; }

    }


}

