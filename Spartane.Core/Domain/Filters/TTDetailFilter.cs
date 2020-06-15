using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class TTDetailFilter:BaseEntity
    {
        public int IdTTFiltro { get; set; }
        public int Folio { get; set; }
        public Nullable<int> DNTFiltro { get; set; }
        public Nullable<int> Dt_Filtro { get; set; }
        public Nullable<bool> Question { get; set; }
        public Nullable<int> DesdeNumerico { get; set; }
        public Nullable<int> HastaNumerico { get; set; }
        public Nullable<System.DateTime> DesdeDate { get; set; }
        public Nullable<System.DateTime> HastaDate { get; set; }
        public Nullable<short> Ano { get; set; }
        public Nullable<short> Mes { get; set; }
        public Nullable<short> Semana { get; set; }
        public Nullable<short> Si_No { get; set; }
        public Nullable<short> CondicionTexto { get; set; }
        public Nullable<short> TipoDeControlBusqueda { get; set; }
        public string RutaDNTs { get; set; }
        public Nullable<decimal> DesdeDecimal { get; set; }
        public Nullable<decimal> HastaDecimal { get; set; }
        public string DesdeTexto { get; set; }
        public string HastaTexto { get; set; }
        public Nullable<int> Filtros_Dependientes { get; set; }
        public Nullable<int> Filtros_Detalle { get; set; }
    }
}
