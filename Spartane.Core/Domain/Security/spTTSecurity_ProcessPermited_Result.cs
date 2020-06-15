using System;

namespace Spartane.Core.Domain.Binnacle
{
    public partial class spTTSecurity_ProcessPermited_Result: BaseEntity
    {
        public short IdGrupoUsuario { get; set; }
        public short IdProceso { get; set; }
        public short IdOperacion { get; set; }
        public short idModulo { get; set; }
    }
}
