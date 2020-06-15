using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Binnacle;

namespace Spartane.Data.EF.Mapping.Security
{
    public partial class DashBoardDataMap : EntityTypeConfiguration<DashBoardData>
    {
        public DashBoardDataMap()
        {
            this.ToTable("TTDashBoards");
            this.HasKey(a => a.Key);
        }
    }
}
