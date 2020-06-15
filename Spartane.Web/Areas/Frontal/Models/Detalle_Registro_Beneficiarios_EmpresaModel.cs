using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Registro_Beneficiarios_EmpresaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Detalle_Registro_Beneficiarios_Empresa_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string SuscripcionNombre_del_Plan { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

