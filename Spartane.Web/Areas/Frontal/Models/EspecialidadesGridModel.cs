using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EspecialidadesGridModel
    {
        public int Clave { get; set; }
        public string Especialidad { get; set; }
        public int? Profesion { get; set; }
        public string ProfesionDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public int? Imagen { get; set; }
        public Grid_File ImagenFileInfo { set; get; }
        
    }
}

