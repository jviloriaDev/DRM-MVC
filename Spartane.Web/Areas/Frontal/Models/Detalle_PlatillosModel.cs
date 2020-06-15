using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_PlatillosModel
    {
        [Required]
        public int Folio { get; set; }
        public bool Lleva_fracciones { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad { get; set; }
        public int? Cantidad_fraccion { get; set; }
        public string Cantidad_fraccionCantidad { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        public string Caracteristica { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad_SMAE { get; set; }
        [Range(0, 9999999999)]
        public int? Equivalente_Unidad_SMAE { get; set; }
        [Range(0, 9999999999)]
        public int? Porciones { get; set; }
        public string Detalle { get; set; }
        public string Detalle_Super { get; set; }

    }
	
	public class Detalle_Platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public bool? Lleva_fracciones { get; set; }
        [Range(0, 9999999999)]
        public int? Cantidad { get; set; }
        public int? Cantidad_fraccion { get; set; }
        public string Cantidad_fraccionCantidad { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string IngredienteNombre_Ingrediente { get; set; }
        public string Caracteristica { get; set; }
        [Range(0, 9999999999)]
        public int? Unidad_SMAE { get; set; }
        [Range(0, 9999999999)]
        public int? Equivalente_Unidad_SMAE { get; set; }
        [Range(0, 9999999999)]
        public int? Porciones { get; set; }
        public string Detalle { get; set; }
        public string Detalle_Super { get; set; }

    }


}

