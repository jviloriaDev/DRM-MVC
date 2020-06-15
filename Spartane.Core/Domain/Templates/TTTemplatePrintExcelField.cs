using System;


namespace Spartane.Core.Domain.Templates
{
    public partial class TTTemplatePrintExcelField: BaseEntity
    {
        public short IdTemplate { get; set; }
        public int Folio { get; set; }
        public Nullable<int> DNTID { get; set; }
        public Nullable<int> DTID { get; set; }
        public Nullable<short> Celda_Row { get; set; }
        public Nullable<short> Celda_Col { get; set; }
        public string RutaDNT { get; set; }
        public string RutaDNTDescripcion { get; set; }
        public string RutaDT { get; set; }
        public string Condicion { get; set; }
        public virtual TTTemplatePrintExcel TTTemplatePrintExcel { get; set; }
    }
}
