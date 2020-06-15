using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Ingredientes
{
    public class IngredientesPagingModel
    {
        public List<Spartane.Core.Domain.Ingredientes.Ingredientes> Ingredientess { set; get; }
        public int RowCount { set; get; }
    }
}
