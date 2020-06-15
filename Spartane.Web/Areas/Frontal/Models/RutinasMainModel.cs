using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class RutinasMainModel
    {
        public RutinasModel RutinasInfo { set; get; }
        public Detalle_Ejercicios_RutinasGridModelPost Detalle_Ejercicios_RutinasGridInfo { set; get; }

    }

    public class Detalle_Ejercicios_RutinasGridModelPost
    {
        public int Folio { get; set; }
        public int? Orden_de_realizacion { get; set; }
        public int? Numero_de_serie { get; set; }
        public int? Ejercicio { get; set; }
        public int? Cantidad_de_Repeticiones { get; set; }

        public bool Removed { set; get; }
    }



}

