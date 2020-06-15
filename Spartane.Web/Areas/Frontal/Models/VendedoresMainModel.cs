using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class VendedoresMainModel
    {
        public VendedoresModel VendedoresInfo { set; get; }
        public Detalle_Codigos_de_Referencia_VendedoresGridModelPost Detalle_Codigos_de_Referencia_VendedoresGridInfo { set; get; }
        public Detalle_Facturacion_VendedoresGridModelPost Detalle_Facturacion_VendedoresGridInfo { set; get; }

    }

    public class Detalle_Codigos_de_Referencia_VendedoresGridModelPost
    {
        public int Folio { get; set; }
        public int? Porcentaje_de_descuento { get; set; }
        public string Fecha_inicio_vigencia { get; set; }
        public string Fecha_fin_vigencia { get; set; }
        public int? Cantidad_maxima_de_referenciados { get; set; }
        public string Codigo_para_referenciados { get; set; }
        public bool? Autorizado { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Facturacion_VendedoresGridModelPost
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        public Grid_File Archivo_XMLInfo { set; get; }
        public int? Archivo_PDF { get; set; }
        public Grid_File Archivo_PDFInfo { set; get; }
        public int? Estatus { get; set; }
        public string Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public string Fecha_de_Pago { get; set; }

        public bool Removed { set; get; }
    }



}

