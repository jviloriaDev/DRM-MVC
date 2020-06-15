using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class IngredientesGridModel
    {
        public int Clave { get; set; }
        public string Nombre_Ingrediente { get; set; }
        public int? Clasificacion { get; set; }
        public string ClasificacionDescripcion { get; set; }
        public int? Imagen { get; set; }
        public Grid_File ImagenFileInfo { set; get; }
        public string Subgrupo { get; set; }
        public decimal? Cantidad_sugerida { get; set; }
        public string Unidad { get; set; }
        public decimal? Peso_bruto_redondeado_g { get; set; }
        public decimal? Peso_neto_g { get; set; }
        public string Nombre_sistema_anterior { get; set; }
        
    }
}

