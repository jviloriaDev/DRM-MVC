using System;

namespace Spartane.Core.Domain.Columns
{
    public partial class TTConfigurationAdvancedColumn_Detalle: BaseEntity
    {
        public int IdConfiguration { get; set; }
        public int IdConfiguraionDetalle { get; set; }
        public Nullable<int> DNT { get; set; }
        public Nullable<int> DT { get; set; }
        public Nullable<bool> Visible { get; set; }
        public Nullable<short> Orden { get; set; }
        public Nullable<short> TipoPresentacion { get; set; }
    }
}
