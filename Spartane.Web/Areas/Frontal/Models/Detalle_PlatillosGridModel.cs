using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_PlatillosGridModel
    {
        public int Folio { get; set; }
        public bool? Lleva_fracciones { get; set; }
        public int? Cantidad { get; set; }
        public int? Cantidad_fraccion { get; set; }
        public string Cantidad_fraccionCantidad { get; set; }
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        public string Caracteristica { get; set; }
        public int? Unidad_SMAE { get; set; }
        public int? Equivalente_Unidad_SMAE { get; set; }
        public int? Porciones { get; set; }
        public string Detalle { get; set; }
        public string Detalle_Super { get; set; }
        
    }
}

