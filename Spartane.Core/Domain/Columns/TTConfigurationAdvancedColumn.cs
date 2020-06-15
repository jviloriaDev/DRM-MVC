using System;

namespace Spartane.Core.Domain.Columns
{
    public partial class TTConfigurationAdvancedColumn:BaseEntity
    {
        //TODO: review the rest of fields included in origin object
        public int IdConfiguration { get; set; }
        public Nullable<int> ProcesoId { get; set; }
        public Nullable<int> Detalle { get; set; }
    }
}
