using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Registro_en_EventoGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Evento { get; set; }
        public string EventoNombre_del_Evento { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_inicio_del_Evento { get; set; }
        public string Fecha_fin_del_Evento { get; set; }
        public string Lugar { get; set; }
        
    }
}

