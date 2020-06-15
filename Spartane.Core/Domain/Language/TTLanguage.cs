using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Language
{
    public partial class TTLanguage : BaseEntity
    {
        public TTLanguage()
        {
            this.TTLanguageTraductions = new HashSet<TTLanguageTraduction>();
        }
    
        public short idLanguage { get; set; }
        public string Idioma { get; set; }
        public Nullable<short> Bandera { get; set; }
        public string Abreviatura { get; set; }
    
        public virtual ICollection<TTLanguageTraduction> TTLanguageTraductions { get; set; }
    }
}
