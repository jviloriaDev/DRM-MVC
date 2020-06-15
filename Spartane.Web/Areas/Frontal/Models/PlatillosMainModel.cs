using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PlatillosMainModel
    {
        public PlatillosModel PlatillosInfo { set; get; }
        public Detalle_de_IngredientesGridModelPost Detalle_de_IngredientesGridInfo { set; get; }
        public Detalle_PlatillosGridModelPost Detalle_PlatillosGridInfo { set; get; }

    }

    public class Detalle_de_IngredientesGridModelPost
    {
        public int Clave { get; set; }
        public string Cantidad { get; set; }
        public int? Unidad { get; set; }
        public int? Nombre_del_Ingrediente { get; set; }
        public int? Nombre_de_presentacion { get; set; }
        public int? Nombre_de_Marca { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_PlatillosGridModelPost
    {
        public int Folio { get; set; }
        public bool? Lleva_fracciones { get; set; }
        public int? Cantidad { get; set; }
        public int? Cantidad_fraccion { get; set; }
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string Caracteristica { get; set; }
        public int? Unidad_SMAE { get; set; }
        public int? Equivalente_Unidad_SMAE { get; set; }
        public int? Porciones { get; set; }
        public string Detalle { get; set; }
        public string Detalle_Super { get; set; }

        public bool Removed { set; get; }
    }



}

