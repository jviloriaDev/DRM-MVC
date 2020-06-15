using Spartane.Core.Domain.Search;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Search
{
    public partial class TTVista_ListaDependientesMap : EntityTypeConfiguration<TTVista_ListaDependientes>
    {
        public TTVista_ListaDependientesMap()
        {
            this.ToTable("TTVista_ListaDependientes");
            this.HasKey(a => new { a.VistaId, a.DTId });
            this.Ignore(a => a.Id1);
        }
    }
}