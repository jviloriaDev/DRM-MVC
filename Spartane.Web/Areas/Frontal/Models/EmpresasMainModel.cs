using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EmpresasMainModel
    {
        public EmpresasModel EmpresasInfo { set; get; }
        public Detalle_Contactos_EmpresaGridModelPost Detalle_Contactos_EmpresaGridInfo { set; get; }
        public Detalle_Suscripciones_EmpresaGridModelPost Detalle_Suscripciones_EmpresaGridInfo { set; get; }
        public Detalle_Pagos_EmpresaGridModelPost Detalle_Pagos_EmpresaGridInfo { set; get; }
        public Detalle_Registro_Beneficiarios_EmpresaGridModelPost Detalle_Registro_Beneficiarios_EmpresaGridInfo { set; get; }
        public Detalle_Contratos_EmpresaGridModelPost Detalle_Contratos_EmpresaGridInfo { set; get; }

    }

    public class Detalle_Contactos_EmpresaGridModelPost
    {
        public int Folio { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool? Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public bool? Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool? Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Suscripciones_EmpresaGridModelPost
    {
        public int Folio { get; set; }
        public int? Cantidad_de_Beneficiarios { get; set; }
        public int? Suscripcion { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Nombre_de_la_Suscripcion { get; set; }
        public int? Frecuencia_de_Pago { get; set; }
        public decimal? Costo { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Pagos_EmpresaGridModelPost
    {
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public string Concepto_de_Pago { get; set; }
        public string Fecha_de_Suscripcion { get; set; }
        public int? Numero_de_Pago { get; set; }
        public int? De_Total_de_Pagos { get; set; }
        public string Fecha_Limite_de_Pago { get; set; }
        public int? Recordatorio_dias { get; set; }
        public int? Forma_de_Pago { get; set; }
        public string Fecha_de_Pago { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Registro_Beneficiarios_EmpresaGridModelPost
    {
        public int Folio { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Contratos_EmpresaGridModelPost
    {
        public int Folio { get; set; }
        public int? Suscripcion { get; set; }
        public int? Tipo_de_Contrato { get; set; }
        public int? Documento { get; set; }
        public Grid_File DocumentoInfo { set; get; }
        public string Fecha_de_Firma_de_Contrato { get; set; }

        public bool Removed { set; get; }
    }



}

