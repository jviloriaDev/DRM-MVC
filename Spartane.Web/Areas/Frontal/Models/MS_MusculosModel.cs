using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MS_MusculosModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Musculo { get; set; }
        public string MusculoDescripcion { get; set; }

    }
	
	public class MS_Musculos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Musculo { get; set; }
        public string MusculoDescripcion { get; set; }

    }


}

