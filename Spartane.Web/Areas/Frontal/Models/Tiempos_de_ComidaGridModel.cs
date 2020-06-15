using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tiempos_de_ComidaGridModel
    {
        public int Clave { get; set; }
        public string Comida { get; set; }
        public string Hora_min { get; set; }
        public string Hora_max { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }
        
    }
}

