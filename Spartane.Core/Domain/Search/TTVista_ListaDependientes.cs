using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Search
{
    public partial class TTVista_ListaDependientes : BaseEntity
    {
        public int VistaId { get; set; }
        public string Valor { get; set; }
        public decimal DTId { get; set; }
    }
}
