using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class IngredientesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_Ingrediente { get; set; }
        public int? Clasificacion { get; set; }
        public string ClasificacionDescripcion { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public string Subgrupo { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Cantidad_sugerida { get; set; }
        public string Unidad { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_bruto_redondeado_g { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_neto_g { get; set; }
        public string Nombre_sistema_anterior { get; set; }

    }
	
	public class Ingredientes_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_Ingrediente { get; set; }
        public int? Clasificacion { get; set; }
        public string ClasificacionDescripcion { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public string Subgrupo { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Cantidad_sugerida { get; set; }
        public string Unidad { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_bruto_redondeado_g { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Peso_neto_g { get; set; }
        public string Nombre_sistema_anterior { get; set; }

    }


}

