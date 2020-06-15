using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class areas_EmpresasModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }

    }
	
	public class areas_Empresas_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }

    }


}

