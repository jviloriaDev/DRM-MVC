using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Rutinas;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Planes_de_Rutinas
{
    /// <summary>
    /// Planes_de_Rutinas table
    /// </summary>
    public class Planes_de_Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_inicio_del_Plan { get; set; }
        public DateTime? Fecha_fin_del_Plan { get; set; }
        public int? Semana { get; set; }
        public int? Paciente { get; set; }
        public int? Rutinas { get; set; }
        public bool? Modificado { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Paciente_Pacientes { get; set; }
        [ForeignKey("Rutinas")]
        public virtual Spartane.Core.Domain.Rutinas.Rutinas Rutinas_Rutinas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Planes_de_Rutinas_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_inicio_del_Plan { get; set; }
        public DateTime? Fecha_fin_del_Plan { get; set; }
        public int? Semana { get; set; }
        public int? Paciente { get; set; }
        public int? Rutinas { get; set; }
        public bool? Modificado { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Paciente")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Paciente_Pacientes { get; set; }
        [ForeignKey("Rutinas")]
        public virtual Spartane.Core.Domain.Rutinas.Rutinas Rutinas_Rutinas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

