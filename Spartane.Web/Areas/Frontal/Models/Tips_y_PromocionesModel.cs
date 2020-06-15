using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tips_y_PromocionesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public string Fecha_inicio_de_Vigencia { get; set; }
        public string Fecha_fin_de_Vigencia { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public int? Especialista { get; set; }
        public string EspecialistaNombre_Completo { get; set; }
        public int? Vendedor { get; set; }
        public string VendedorName { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Tips_y_Promociones_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public string Fecha_inicio_de_Vigencia { get; set; }
        public string Fecha_fin_de_Vigencia { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadEspecialidad { get; set; }
        public int? Especialista { get; set; }
        public string EspecialistaNombre_Completo { get; set; }
        public int? Vendedor { get; set; }
        public string VendedorName { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

