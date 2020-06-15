using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EstadoGridModel
    {
        public int Clave { get; set; }
        public string Nombre_del_Estado { get; set; }
        public int? Folio_Pais { get; set; }
        public string Folio_PaisNombre_del_Pais { get; set; }
        
    }
}

