using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Preferencia_BebidasModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Bebida { get; set; }
        public string BebidaDescripcion { get; set; }
        public int? Cantidad { get; set; }
        public string CantidadDescripcion { get; set; }

    }
	
	public class Detalle_Preferencia_Bebidas_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Bebida { get; set; }
        public string BebidaDescripcion { get; set; }
        public int? Cantidad { get; set; }
        public string CantidadDescripcion { get; set; }

    }


}

