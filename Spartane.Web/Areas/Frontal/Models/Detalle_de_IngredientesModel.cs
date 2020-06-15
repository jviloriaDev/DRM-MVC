using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_IngredientesModel
    {
        [Required]
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
	
	public class Detalle_de_Ingredientes_Datos_GeneralesModel
    {
        [Required]
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

