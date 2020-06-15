using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EjerciciosMainModel
    {
        public EjerciciosModel EjerciciosInfo { set; get; }
        public MS_Equipamiento_para_EjerciciosGridModelPost MS_Equipamiento_para_EjerciciosGridInfo { set; get; }

    }

    public class MS_Equipamiento_para_EjerciciosGridModelPost
    {
        public int Folio { get; set; }
        public int? Equipamento { get; set; }

        public bool Removed { set; get; }
    }



}

