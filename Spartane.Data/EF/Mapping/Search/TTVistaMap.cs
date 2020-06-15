using Spartane.Core.Domain.Search;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Search
{
    public partial class TTVistaMap : EntityTypeConfiguration<TTVista>
    {
        public TTVistaMap()
        {
            this.ToTable("TTVista");
            this.HasKey(a => a.Vistaid);
            this.Ignore(a => a.Id1);
        }
    }
}
