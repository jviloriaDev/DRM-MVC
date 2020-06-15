using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Datos_Bancarios_EspecialistasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Banco { get; set; }
        public string BancoNombre { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Num_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public bool Principal { get; set; }

    }
	
	public class Datos_Bancarios_Especialistas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Banco { get; set; }
        public string BancoNombre { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Num_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public bool? Principal { get; set; }

    }


}

