using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Interpretacion_de_porcentaje_de_grasa_corporalModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }

    }
	
	public class Interpretacion_de_porcentaje_de_grasa_corporal_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Descripcion { get; set; }

    }


}

