using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PlatillosAdvanceSearchModel
    {
        public PlatillosAdvanceSearchModel()
        {
            Imagen = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFolio { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFolio", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFolio { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Registro { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Registro", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Registro { set; get; }

        public string ToHora_de_Registro { set; get; }
        public string FromHora_de_Registro { set; get; }

        public Filters Usuario_que_RegistraFilter { set; get; }
        public string AdvanceUsuario_que_Registra { set; get; }
        public int[] AdvanceUsuario_que_RegistraMultiple { set; get; }

        public Filters Nombre_de_PlatilloFilter { set; get; }
        public string Nombre_de_Platillo { set; get; }

        public RadioOptions Imagen { set; get; }

        public Filters CaloriasFilter { set; get; }
        public string AdvanceCalorias { set; get; }
        public int[] AdvanceCaloriasMultiple { set; get; }

        public Filters DificultadFilter { set; get; }
        public string AdvanceDificultad { set; get; }
        public int[] AdvanceDificultadMultiple { set; get; }

        public Filters Categoria_del_PlatilloFilter { set; get; }
        public string AdvanceCategoria_del_Platillo { set; get; }
        public int[] AdvanceCategoria_del_PlatilloMultiple { set; get; }

        public Filters Tiempo_de_comidaFilter { set; get; }
        public string AdvanceTiempo_de_comida { set; get; }
        public int[] AdvanceTiempo_de_comidaMultiple { set; get; }

        public Filters Tipo_de_comidaFilter { set; get; }
        public string AdvanceTipo_de_comida { set; get; }
        public int[] AdvanceTipo_de_comidaMultiple { set; get; }

        public Filters CaracteristicasFilter { set; get; }
        public string AdvanceCaracteristicas { set; get; }
        public int[] AdvanceCaracteristicasMultiple { set; get; }

        public Filters CalificacionFilter { set; get; }
        public string Calificacion { set; get; }

        public Filters Modo_de_PreparacionFilter { set; get; }
        public string Modo_de_Preparacion { set; get; }


    }
}
