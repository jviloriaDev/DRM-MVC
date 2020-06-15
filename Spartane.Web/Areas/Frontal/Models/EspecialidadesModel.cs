using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EspecialidadesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Especialidad { get; set; }
        public int? Profesion { get; set; }
        public string ProfesionDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }

    }
	
	public class Especialidades_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Especialidad { get; set; }
        public int? Profesion { get; set; }
        public string ProfesionDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }

    }


}

