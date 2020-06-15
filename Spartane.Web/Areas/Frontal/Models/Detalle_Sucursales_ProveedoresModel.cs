using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Sucursales_ProveedoresModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_de_Sucursal { get; set; }
        public string Tipo_de_SucursalDescripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_exterior { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_interior { get; set; }
        public string Colonia { get; set; }
        [Range(0, 9999999999)]
        public int? C_P_ { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

    }
	
	public class Detalle_Sucursales_Proveedores_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Tipo_de_Sucursal { get; set; }
        public string Tipo_de_SucursalDescripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_exterior { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_interior { get; set; }
        public string Colonia { get; set; }
        [Range(0, 9999999999)]
        public int? C_P_ { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

    }


}

