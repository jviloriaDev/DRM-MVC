using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Templates
{
    public partial class TTTemplatePrintExcel: BaseEntity
    {
        public TTTemplatePrintExcel()
        {
            this.TTTemplatePrintExcelFields = new HashSet<TTTemplatePrintExcelField>();
        }
        public short IdTemplate { get; set; }
        public Nullable<short> ProcesoId { get; set; }
        public string Descripcion { get; set; }
        public Nullable<short> Archivo { get; set; }
        public Nullable<int> ConfiguracionCampos { get; set; }
        public Nullable<short> Ajustar { get; set; }
        public Nullable<short> Paginas_Alto { get; set; }
        public Nullable<short> Paginas_Ancho { get; set; }
        public virtual ICollection<TTTemplatePrintExcelField> TTTemplatePrintExcelFields { get; set; }
    }
}
