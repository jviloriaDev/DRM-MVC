using Spartane.Core.Domain.Language;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Language
{
    public partial class TTLanguageTraductionMap : EntityTypeConfiguration<TTLanguageTraduction>
    {
        public TTLanguageTraductionMap()
        {
            this.ToTable("TTLanguageTraduction");
            this.HasKey(a => a.idTraduction);
            this.Ignore(a => a.Id1);
        }
    }
}