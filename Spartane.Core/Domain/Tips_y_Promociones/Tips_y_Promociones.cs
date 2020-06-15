using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tips_y_Promociones
{
    /// <summary>
    /// Tips_y_Promociones table
    /// </summary>
    public class Tips_y_Promociones: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public int? Imagen { get; set; }
        //public string Imagen_URL { get; set; }
        public DateTime? Fecha_inicio_de_Vigencia { get; set; }
        public DateTime? Fecha_fin_de_Vigencia { get; set; }
        public int? Especialidad { get; set; }
        public int? Especialista { get; set; }
        public int? Vendedor { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Domain.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Especialista_Medicos { get; set; }
        [ForeignKey("Vendedor")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Vendedor_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Tips_y_Promociones_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public int? Imagen { get; set; }
        public string Imagen_URL { get; set; }
        public DateTime? Fecha_inicio_de_Vigencia { get; set; }
        public DateTime? Fecha_fin_de_Vigencia { get; set; }
        public int? Especialidad { get; set; }
        public int? Especialista { get; set; }
        public int? Vendedor { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Domain.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Especialista_Medicos { get; set; }
        [ForeignKey("Vendedor")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Vendedor_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

