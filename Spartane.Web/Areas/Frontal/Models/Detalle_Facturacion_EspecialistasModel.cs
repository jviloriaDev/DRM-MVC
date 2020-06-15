using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Facturacion_EspecialistasModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        public HttpPostedFileBase Archivo_XMLFile { set; get; }
        public int Archivo_XMLRemoveAttachment { set; get; }
        public int? Archivo_PDF { get; set; }
        public HttpPostedFileBase Archivo_PDFFile { set; get; }
        public int Archivo_PDFRemoveAttachment { set; get; }
        [Range(0, 9999999999)]
        public int? Estatus { get; set; }
        public string Fecha_programada_de_Pago { get; set; }
        public bool Pagada { get; set; }
        public string Fecha_de_pago { get; set; }

    }
	
	public class Detalle_Facturacion_Especialistas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        public HttpPostedFileBase Archivo_XMLFile { set; get; }
        public int Archivo_XMLRemoveAttachment { set; get; }
        public int? Archivo_PDF { get; set; }
        public HttpPostedFileBase Archivo_PDFFile { set; get; }
        public int Archivo_PDFRemoveAttachment { set; get; }
        [Range(0, 9999999999)]
        public int? Estatus { get; set; }
        public string Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public string Fecha_de_pago { get; set; }

    }


}

