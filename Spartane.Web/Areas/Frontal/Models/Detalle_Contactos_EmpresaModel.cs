using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Contactos_EmpresaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public string AreaNombre { get; set; }
        public bool Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Contactos_Empresa_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool? Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public string AreaNombre { get; set; }
        public bool? Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool? Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

