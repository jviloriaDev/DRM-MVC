using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EmpresasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_la_Empresa { get; set; }
        public int? Tipo_de_Empresa { get; set; }
        public string Tipo_de_EmpresaDescripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        [Range(0, 9999999999)]
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre_del_Estado { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Regimen_FiscalDescripcion { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public string Numero_exterior_Fiscal { get; set; }
        public string Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        [Range(0, 9999999999)]
        public int? CP_Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public string Estado_FiscalNombre_del_Estado { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Pais_FiscalNombre_del_Pais { get; set; }
        public string Telefono_Fiscal { get; set; }
        public string Fax { get; set; }
        public string Nombres_del_Representante_Legal { get; set; }
        public string Apellido_Paterno_del_Representante_Legal { get; set; }
        public string Apellido_Materno_del_Representante_Legal { get; set; }
        public string Nombre_Completo_del_Representante_Legal { get; set; }
        public int? Cedula_Fiscal { get; set; }
        public HttpPostedFileBase Cedula_FiscalFile { set; get; }
        public int Cedula_FiscalRemoveAttachment { set; get; }

    }
	
	public class Empresas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_la_Empresa { get; set; }
        public int? Tipo_de_Empresa { get; set; }
        public string Tipo_de_EmpresaDescripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        [Range(0, 9999999999)]
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre_del_Estado { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }

	public class Empresas_Datos_de_ContactoModel
    {
        [Required]
        public int Folio { get; set; }

    }

	public class Empresas_Datos_FiscalesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Regimen_FiscalDescripcion { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public string Numero_exterior_Fiscal { get; set; }
        public string Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        [Range(0, 9999999999)]
        public int? CP_Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public string Estado_FiscalNombre_del_Estado { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Pais_FiscalNombre_del_Pais { get; set; }
        public string Telefono_Fiscal { get; set; }
        public string Fax { get; set; }
        public string Nombres_del_Representante_Legal { get; set; }
        public string Apellido_Paterno_del_Representante_Legal { get; set; }
        public string Apellido_Materno_del_Representante_Legal { get; set; }
        public string Nombre_Completo_del_Representante_Legal { get; set; }

    }

	public class Empresas_SuscripcionModel
    {
        [Required]
        public int Folio { get; set; }

    }

	public class Empresas_DocumentacionModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Cedula_Fiscal { get; set; }
        public HttpPostedFileBase Cedula_FiscalFile { set; get; }
        public int Cedula_FiscalRemoveAttachment { set; get; }

    }


}

