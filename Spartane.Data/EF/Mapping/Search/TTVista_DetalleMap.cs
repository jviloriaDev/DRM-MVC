using Spartane.Core.Domain.Search;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spartane.Data.EF.Mapping.Search
{
    public partial class TTVista_DetalleMap : EntityTypeConfiguration<TTVista_Detalle>
    {
        public TTVista_DetalleMap()
        {
            this.ToTable("TTVista_Detalle");
            this.HasKey(a => new { a.VistaId, a.Dtid });
            this.Ignore(a => a.Id1);
        }
    }
}
