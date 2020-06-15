using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Facturacion_Especialistas
{
    /// <summary>
    /// Detalle_Facturacion_Especialistas table
    /// </summary>
    public class Detalle_Facturacion_Especialistas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        //public string Archivo_XML_URL { get; set; }
        public int? Archivo_PDF { get; set; }
        //public string Archivo_PDF_URL { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public DateTime? Fecha_de_pago { get; set; }

        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Archivo_XML")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Archivo_XML_Spartane_File { get; set; }
        [ForeignKey("Archivo_PDF")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Archivo_PDF_Spartane_File { get; set; }

    }
	
	public class Detalle_Facturacion_Especialistas_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Folio_Factura { get; set; }
        public string Periodo_Facturado { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Archivo_XML { get; set; }
        public string Archivo_XML_URL { get; set; }
        public int? Archivo_PDF { get; set; }
        public string Archivo_PDF_URL { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Fecha_programada_de_Pago { get; set; }
        public bool? Pagada { get; set; }
        public DateTime? Fecha_de_pago { get; set; }

		        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Archivo_XML")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Archivo_XML_Spartane_File { get; set; }
        [ForeignKey("Archivo_PDF")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Archivo_PDF_Spartane_File { get; set; }

    }


}

