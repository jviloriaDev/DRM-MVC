using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente
{
    public class Detalle_Caracteristicas_IngredientePagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> Detalle_Caracteristicas_Ingredientes { set; get; }
        public int RowCount { set; get; }
    }
}
