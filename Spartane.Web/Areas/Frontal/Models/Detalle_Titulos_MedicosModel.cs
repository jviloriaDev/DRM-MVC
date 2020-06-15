using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Titulos_MedicosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre_del_Titulo { get; set; }
        public string Institucion_Facultad { get; set; }
        public string Fecha_de_Titulacion { get; set; }
        public int? Titulo { get; set; }
        public HttpPostedFileBase TituloFile { set; get; }
        public int TituloRemoveAttachment { set; get; }
        public string Numero_de_Cedula { get; set; }
        public string Fecha_de_Expedicion { get; set; }
        public int? Cedula_Frente { get; set; }
        public HttpPostedFileBase Cedula_FrenteFile { set; get; }
        public int Cedula_FrenteRemoveAttachment { set; get; }
        public int? Cedula_Reverso { get; set; }
        public HttpPostedFileBase Cedula_ReversoFile { set; get; }
        public int Cedula_ReversoRemoveAttachment { set; get; }

    }
	
	public class Detalle_Titulos_Medicos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Nombre_del_Titulo { get; set; }
        public string Institucion_Facultad { get; set; }
        public string Fecha_de_Titulacion { get; set; }
        public int? Titulo { get; set; }
        public HttpPostedFileBase TituloFile { set; get; }
        public int TituloRemoveAttachment { set; get; }
        public string Numero_de_Cedula { get; set; }
        public string Fecha_de_Expedicion { get; set; }
        public int? Cedula_Frente { get; set; }
        public HttpPostedFileBase Cedula_FrenteFile { set; get; }
        public int Cedula_FrenteRemoveAttachment { set; get; }
        public int? Cedula_Reverso { get; set; }
        public HttpPostedFileBase Cedula_ReversoFile { set; get; }
        public int Cedula_ReversoRemoveAttachment { set; get; }

    }


}

