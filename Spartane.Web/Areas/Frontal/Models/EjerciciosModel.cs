using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EjerciciosModel
    {
        [Required]
        public int Clave { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_del_Ejercicio { get; set; }
        public string Descripcion_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public string Tipo_de_EjercicioDescripcion { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultadDificultad { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Musculos_trabajados { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public int? Video { get; set; }
        public HttpPostedFileBase VideoFile { set; get; }
        public int VideoRemoveAttachment { set; get; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Ejercicios_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_del_Ejercicio { get; set; }
        public string Descripcion_del_Ejercicio { get; set; }
        public int? Tipo_de_Ejercicio { get; set; }
        public string Tipo_de_EjercicioDescripcion { get; set; }
        public int? Nivel_de_dificultad { get; set; }
        public string Nivel_de_dificultadDificultad { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Musculos_trabajados { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public int? Video { get; set; }
        public HttpPostedFileBase VideoFile { set; get; }
        public int VideoRemoveAttachment { set; get; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

