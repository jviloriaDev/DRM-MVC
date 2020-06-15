using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Planes_de_RutinasMainModel
    {
        public Planes_de_RutinasModel Planes_de_RutinasInfo { set; get; }
        public Detalle_Planes_de_RutinasGridModelPost Detalle_Planes_de_RutinasGridInfo { set; get; }

    }

    public class Detalle_Planes_de_RutinasGridModelPost
    {
        public int Folio { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Fecha { get; set; }
        public bool? Realizado { get; set; }

        public bool Removed { set; get; }
    }



}

