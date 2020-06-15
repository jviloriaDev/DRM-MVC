using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Ubicaciones_Eventos_EmpresaModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Cupo { get; set; }
        public int? Ubicacion_externa { get; set; }
        public string Ubicacion_externaDescripcion { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public int? Empresa { get; set; }
        public string EmpresaNombre_de_la_Empresa { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }
	
	public class Ubicaciones_Eventos_Empresa_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Cupo { get; set; }
        public int? Ubicacion_externa { get; set; }
        public string Ubicacion_externaDescripcion { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public int? Empresa { get; set; }
        public string EmpresaNombre_de_la_Empresa { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }

    }


}

