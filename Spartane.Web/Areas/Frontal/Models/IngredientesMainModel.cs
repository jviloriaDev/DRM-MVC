using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class IngredientesMainModel
    {
        public IngredientesModel IngredientesInfo { set; get; }
        public Detalle_Caracteristicas_IngredienteGridModelPost Detalle_Caracteristicas_IngredienteGridInfo { set; get; }

    }

    public class Detalle_Caracteristicas_IngredienteGridModelPost
    {
        public int Folio { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

        public bool Removed { set; get; }
    }



}

