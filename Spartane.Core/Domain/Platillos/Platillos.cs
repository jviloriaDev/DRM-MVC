using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.Calorias;
using Spartane.Core.Domain.Dificultad_de_platillos;
using Spartane.Core.Domain.Categorias_de_platillos;
using Spartane.Core.Domain.Tiempos_de_Comida;
using Spartane.Core.Domain.Tipo_de_comida_platillos;
using Spartane.Core.Domain.Caracteristicas_platillo;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Platillos
{
    /// <summary>
    /// Platillos table
    /// </summary>
    public class Platillos: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_Platillo { get; set; }
        public int? Imagen { get; set; }
        //public string Imagen_URL { get; set; }
        public int? Calorias { get; set; }
        public int? Dificultad { get; set; }
        public int? Categoria_del_Platillo { get; set; }
        public int? Tiempo_de_comida { get; set; }
        public int? Tipo_de_comida { get; set; }
        public int? Caracteristicas { get; set; }
        public string Calificacion { get; set; }
        public string Modo_de_Preparacion { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Calorias")]
        public virtual Spartane.Core.Domain.Calorias.Calorias Calorias_Calorias { get; set; }
        [ForeignKey("Dificultad")]
        public virtual Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos Dificultad_Dificultad_de_platillos { get; set; }
        [ForeignKey("Categoria_del_Platillo")]
        public virtual Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos Categoria_del_Platillo_Categorias_de_platillos { get; set; }
        [ForeignKey("Tiempo_de_comida")]
        public virtual Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida Tiempo_de_comida_Tiempos_de_Comida { get; set; }
        [ForeignKey("Tipo_de_comida")]
        public virtual Spartane.Core.Domain.Tipo_de_comida_platillos.Tipo_de_comida_platillos Tipo_de_comida_Tipo_de_comida_platillos { get; set; }
        [ForeignKey("Caracteristicas")]
        public virtual Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo Caracteristicas_Caracteristicas_platillo { get; set; }

    }
	
	public class Platillos_Datos_Generales
    {
                public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Nombre_de_Platillo { get; set; }
        public int? Imagen { get; set; }
        public string Imagen_URL { get; set; }
        public int? Calorias { get; set; }
        public int? Dificultad { get; set; }
        public int? Categoria_del_Platillo { get; set; }
        public int? Tiempo_de_comida { get; set; }
        public int? Tipo_de_comida { get; set; }
        public int? Caracteristicas { get; set; }
        public string Calificacion { get; set; }
        public string Modo_de_Preparacion { get; set; }

		        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Domain.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }
        [ForeignKey("Calorias")]
        public virtual Spartane.Core.Domain.Calorias.Calorias Calorias_Calorias { get; set; }
        [ForeignKey("Dificultad")]
        public virtual Spartane.Core.Domain.Dificultad_de_platillos.Dificultad_de_platillos Dificultad_Dificultad_de_platillos { get; set; }
        [ForeignKey("Categoria_del_Platillo")]
        public virtual Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos Categoria_del_Platillo_Categorias_de_platillos { get; set; }
        [ForeignKey("Tiempo_de_comida")]
        public virtual Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida Tiempo_de_comida_Tiempos_de_Comida { get; set; }
        [ForeignKey("Tipo_de_comida")]
        public virtual Spartane.Core.Domain.Tipo_de_comida_platillos.Tipo_de_comida_platillos Tipo_de_comida_Tipo_de_comida_platillos { get; set; }
        [ForeignKey("Caracteristicas")]
        public virtual Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo Caracteristicas_Caracteristicas_platillo { get; set; }

    }


}

