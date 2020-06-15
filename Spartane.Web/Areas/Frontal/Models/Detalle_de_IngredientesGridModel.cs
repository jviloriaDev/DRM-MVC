using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_IngredientesGridModel
    {
        public int Clave { get; set; }
        public string Cantidad { get; set; }
        public int? Unidad { get; set; }
        public string UnidadUnidad { get; set; }
        public int? Nombre_del_Ingrediente { get; set; }
        public string Nombre_del_IngredienteNombre_Ingrediente { get; set; }
        public int? Nombre_de_presentacion { get; set; }
        public string Nombre_de_presentacionDescripcion { get; set; }
        public int? Nombre_de_Marca { get; set; }
        public string Nombre_de_MarcaDescripcion { get; set; }
        
    }
}

