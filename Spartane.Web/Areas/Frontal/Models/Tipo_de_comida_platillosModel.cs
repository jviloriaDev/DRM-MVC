using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tipo_de_comida_platillosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Tipo_de_comida { get; set; }

    }
	
	public class Tipo_de_comida_platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Tipo_de_comida { get; set; }

    }


}

