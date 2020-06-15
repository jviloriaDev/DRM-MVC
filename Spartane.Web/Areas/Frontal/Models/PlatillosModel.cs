using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PlatillosModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_Platillo { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public int? Calorias { get; set; }
        public string CaloriasCantidad { get; set; }
        public int? Dificultad { get; set; }
        public string DificultadCategoria { get; set; }
        public int? Categoria_del_Platillo { get; set; }
        public string Categoria_del_PlatilloCategoria { get; set; }
        public int? Tiempo_de_comida { get; set; }
        public string Tiempo_de_comidaComida { get; set; }
        public int? Tipo_de_comida { get; set; }
        public string Tipo_de_comidaTipo_de_comida { get; set; }
        public int? Caracteristicas { get; set; }
        public string CaracteristicasCaracteristicas { get; set; }
        public string Calificacion { get; set; }
        public string Modo_de_Preparacion { get; set; }

    }
	
	public class Platillos_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_Platillo { get; set; }
        public int? Imagen { get; set; }
        public HttpPostedFileBase ImagenFile { set; get; }
        public int ImagenRemoveAttachment { set; get; }
        public int? Calorias { get; set; }
        public string CaloriasCantidad { get; set; }
        public int? Dificultad { get; set; }
        public string DificultadCategoria { get; set; }
        public int? Categoria_del_Platillo { get; set; }
        public string Categoria_del_PlatilloCategoria { get; set; }
        public int? Tiempo_de_comida { get; set; }
        public string Tiempo_de_comidaComida { get; set; }
        public int? Tipo_de_comida { get; set; }
        public string Tipo_de_comidaTipo_de_comida { get; set; }
        public int? Caracteristicas { get; set; }
        public string CaracteristicasCaracteristicas { get; set; }
        public string Calificacion { get; set; }
        public string Modo_de_Preparacion { get; set; }

    }


}

