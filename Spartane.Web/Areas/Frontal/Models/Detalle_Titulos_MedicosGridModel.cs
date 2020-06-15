using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Titulos_MedicosGridModel
    {
        public int Folio { get; set; }
        public string Nombre_del_Titulo { get; set; }
        public string Institucion_Facultad { get; set; }
        public string Fecha_de_Titulacion { get; set; }
        public int? Titulo { get; set; }
        public Grid_File TituloFileInfo { set; get; }
        public string Numero_de_Cedula { get; set; }
        public string Fecha_de_Expedicion { get; set; }
        public int? Cedula_Frente { get; set; }
        public Grid_File Cedula_FrenteFileInfo { set; get; }
        public int? Cedula_Reverso { get; set; }
        public Grid_File Cedula_ReversoFileInfo { set; get; }
        
    }
}

