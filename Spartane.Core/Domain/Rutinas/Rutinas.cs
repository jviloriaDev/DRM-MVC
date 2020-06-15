using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Nivel_de_Intensidad;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Rutinas
{
    /// <summary>
    /// Rutinas table
    /// </summary>
    public class Rutinas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_la_Rutina { get; set; }
        public string Descripcion { get; set; }
        public string Equipamento { get; set; }
        public string Equipamento_alterno { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public int? Intensidad { get; set; }
        public int? Duracion_aproximada_minutos { get; set; }
        public int? Genero { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Nivel_de_dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Intensidad")]
        public virtual Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad Intensidad_Nivel_de_Intensidad { get; set; }
        [ForeignKey("Genero")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Genero_Sexo { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Rutinas_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_la_Rutina { get; set; }
        public string Descripcion { get; set; }
        public string Equipamento { get; set; }
        public string Equipamento_alterno { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public int? Intensidad { get; set; }
        public int? Duracion_aproximada_minutos { get; set; }
        public int? Genero { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Nivel_de_dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Intensidad")]
        public virtual Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad Intensidad_Nivel_de_Intensidad { get; set; }
        [ForeignKey("Genero")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Genero_Sexo { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

