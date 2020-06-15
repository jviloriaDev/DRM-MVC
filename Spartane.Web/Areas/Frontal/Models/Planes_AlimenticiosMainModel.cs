using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_AlimenticiosMainModel
    {
        public Planes_AlimenticiosModel Planes_AlimenticiosInfo { set; get; }
        public Detalle_Planes_AlimenticiosGridModelPost Detalle_Planes_AlimenticiosGridInfo { set; get; }

    }

    public class Detalle_Planes_AlimenticiosGridModelPost
    {
        public int Folio { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Fecha { get; set; }
        public int? Platillo { get; set; }
        public bool? Modificado { get; set; }

        public bool Removed { set; get; }
    }



}

