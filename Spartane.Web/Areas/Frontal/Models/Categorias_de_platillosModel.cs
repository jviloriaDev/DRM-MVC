using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Categorias_de_platillosModel
    {
        [Required]
        public int Clave { get; set; }
        public string Categoria { get; set; }

    }
	
	public class Categorias_de_platillos_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Categoria { get; set; }

    }


}

