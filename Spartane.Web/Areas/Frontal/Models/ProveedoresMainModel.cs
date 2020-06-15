using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ProveedoresMainModel
    {
        public ProveedoresModel ProveedoresInfo { set; get; }
        public Detalle_Sucursales_ProveedoresGridModelPost Detalle_Sucursales_ProveedoresGridInfo { set; get; }
        public Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModelPost Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridInfo { set; get; }

    }

    public class Detalle_Sucursales_ProveedoresGridModelPost
    {
        public int Folio { get; set; }
        public int? Tipo_de_Sucursal { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public int? Numero_exterior { get; set; }
        public int? Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? C_P_ { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModelPost
    {
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Fecha_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public Grid_File ContratoInfo { set; get; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }



}

