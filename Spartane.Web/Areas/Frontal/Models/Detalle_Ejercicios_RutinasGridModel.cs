using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Ejercicios_RutinasGridModel
    {
        public int Folio { get; set; }
        public int? Orden_de_realizacion { get; set; }
        public int? Numero_de_serie { get; set; }
        public int? Ejercicio { get; set; }
        public string EjercicioNombre_del_Ejercicio { get; set; }
        public int? Cantidad_de_Repeticiones { get; set; }
        
    }
}

