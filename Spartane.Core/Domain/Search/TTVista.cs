using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Search
{
    public partial class TTVista : BaseEntity
    {
        public int Vistaid { get; set; }
        public string Nombre { get; set; }
        public Nullable<bool> Default { get; set; }
        public Nullable<bool> Vacio { get; set; }
        public Nullable<int> ProcesoId { get; set; }
        public Nullable<int> Usuario { get; set; }
        public string SQL { get; set; }
        public bool Obligatorio { get; set; }
        public Nullable<int> Filtros { get; set; }
        public Nullable<int> Configuracion { get; set; }
    }
}
