using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_Ejercicio;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Ejercicios
{
    /// <summary>
    /// Ejercicios table
    /// </summary>
    public class Ejercicios: BaseEntity
    {
        public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_del_Ejercicio { get; set; }
        public string Descripcion_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public int? Sexo { get; set; }
        public int? Musculos_trabajados { get; set; }
        public int? Imagen { get; set; }
        //public string Imagen_URL { get; set; }
        public int? Video { get; set; }
        //public string Video_URL { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio Tipo_de_Ejercicio_Tipo_Ejercicio { get; set; }
        [ForeignKey("Nivel_de_dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Video")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Video_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Ejercicios_Datos_Generales
    {
                public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_del_Ejercicio { get; set; }
        public string Descripcion_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public int? Sexo { get; set; }
        public int? Musculos_trabajados { get; set; }
        public int? Imagen { get; set; }
        public string Imagen_URL { get; set; }
        public int? Video { get; set; }
        public string Video_URL { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Tipo_de_Ejercicio")]
        public virtual Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio Tipo_de_Ejercicio_Tipo_Ejercicio { get; set; }
        [ForeignKey("Nivel_de_dificultad")]
        public virtual Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad Nivel_de_dificultad_Nivel_de_dificultad { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Video")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Video_Spartane_File { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

