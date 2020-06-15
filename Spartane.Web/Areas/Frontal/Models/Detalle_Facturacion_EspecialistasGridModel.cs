using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Facturacion_EspecialistasGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        public Grid_File Archivo_XMLFileInfo { set; get; }
        public int? Archivo_PDF { get; set; }
        public Grid_File Archivo_PDFFileInfo { set; get; }
        public int? Estatus { get; set; }
        public string Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public string Fecha_de_pago { get; set; }
        
    }
}

