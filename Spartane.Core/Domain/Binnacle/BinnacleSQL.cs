using System;
using System.Collections.Generic;
using Spartane.Core.Domain.User;

namespace Spartane.Core.Domain.Binnacle
{
    public partial class BinnacleSQL: BaseEntity
    {
        public long Folio { get; set; }
        public Nullable<short> IdUsuario { get; set; }
        public string TipoSQL { get; set; }
        public Nullable<System.DateTime> FechaHora { get; set; }
        public string ComputerName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string SystemName { get; set; }
        public Nullable<decimal> SystemVersion { get; set; }
        public string WindowsVersion { get; set; }
        public string CommandSQL { get; set; }
        public string FolioSQL { get; set; }
        public Nullable<short> ProcesoID { get; set; }
        public string IP { get; set; }
        public string DNSName { get; set; }
        public string InfoCliente { get; set; }

        public virtual TTUsuario TTUsuario { get; set; }
    }
}
