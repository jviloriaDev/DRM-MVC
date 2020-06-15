using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Convenio_Medicos_AseguradorasGridModel
    {
        public int Folio { get; set; }
        public int? Aseguradora_medico { get; set; }
        public string Aseguradora_medicoNombre { get; set; }
        
    }
}

