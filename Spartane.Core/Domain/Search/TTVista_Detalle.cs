using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Search
{
    public partial class TTVista_Detalle : BaseEntity
    {
        public int VistaId { get; set; }
        public int DNTid { get; set; }
        public decimal Dtid { get; set; }
        public Nullable<bool> Visible { get; set; }
        public Nullable<int> Orden { get; set; }
        public string Orden_desde { get; set; }
        public string Orden_hasta { get; set; }
        public Nullable<System.DateTime> Orden_Desde_Date { get; set; }
        public Nullable<System.DateTime> Orden_Hasta_Date { get; set; }
        public Nullable<short> Año { get; set; }
        public Nullable<short> Mes { get; set; }
        public Nullable<short> Semana { get; set; }
        public Nullable<short> SI_NO { get; set; }
        public Nullable<short> Condicion { get; set; }
        public Nullable<short> Lista { get; set; }
        public Nullable<short> Presentacion { get; set; }
        public Nullable<short> TipoDeControlBusqueda { get; set; }
    }
}
