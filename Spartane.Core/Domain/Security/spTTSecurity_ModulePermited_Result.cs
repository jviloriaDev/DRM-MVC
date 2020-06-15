using System;

namespace Spartane.Core.Domain.Binnacle
{
    public partial class spTTSecurity_ModulesPermited_Result: BaseEntity
    {
        public short IdModulo { get; set; }
        public string Nombre { get; set; }
        public Nullable<short> Procesos { get; set; }
        public short IdProceso { get; set; }
        public string Nombre1 { get; set; }
        public string Pantalla { get; set; }
        public Nullable<int> DNTID { get; set; }
        public string Nombre_Tabla { get; set; }
        public Nullable<short> renglones_maximo { get; set; }
        public Nullable<short> renglones_minimo { get; set; }
        public string DescriptionProcess { get; set; }
    }
}
