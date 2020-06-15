using Spartane.Core.Domain.Language;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Language
{
    public partial class TTLanguageMap : EntityTypeConfiguration<TTLanguage>
    {
        public TTLanguageMap()
        {
            this.ToTable("TTLanguage");
            this.HasKey(a => a.idLanguage);
            this.Ignore(a => a.Id1);
        }
    }
}