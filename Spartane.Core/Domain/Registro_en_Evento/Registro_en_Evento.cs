using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Eventos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Registro_en_Evento
{
    /// <summary>
    /// Registro_en_Evento table
    /// </summary>
    public class Registro_en_Evento: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_inicio_del_Evento { get; set; }
        public DateTime? Fecha_fin_del_Evento { get; set; }
        public string Lugar { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Evento")]
        public virtual Spartane.Core.Domain.Eventos.Eventos Evento_Eventos { get; set; }

    }
	
	public class Registro_en_Evento_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Evento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_inicio_del_Evento { get; set; }
        public DateTime? Fecha_fin_del_Evento { get; set; }
        public string Lugar { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Evento")]
        public virtual Spartane.Core.Domain.Eventos.Eventos Evento_Eventos { get; set; }

    }


}

