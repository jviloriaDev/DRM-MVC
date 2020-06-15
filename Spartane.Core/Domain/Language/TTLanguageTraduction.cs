using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Language
{
    public partial class TTLanguageTraduction : BaseEntity
    {
        public int idTraduction { get; set; }
        public string Texto { get; set; }
        public Nullable<short> Idioma { get; set; }
        public Nullable<short> RelacionProceso { get; set; }
        public Nullable<int> RelacionDominio { get; set; }
        public Nullable<int> RelacionDT { get; set; }
        public Nullable<int> RelacionMessage { get; set; }
    }
}
