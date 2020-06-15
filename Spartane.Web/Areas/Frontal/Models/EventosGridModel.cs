using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class EventosGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Empresa { get; set; }
        public string EmpresaNombre_de_la_Empresa { get; set; }
        public string Nombre_del_Evento { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_inicio_del_Evento { get; set; }
        public string Fecha_fin_del_Evento { get; set; }
        public int? Cantidad_de_dias { get; set; }
        public int? Evento_en_Empresa { get; set; }
        public string Evento_en_EmpresaDescripcion { get; set; }
        public string Nombre_del_Lugar { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre_del_Estado { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre_del_Pais { get; set; }
        public int? Permite_Familiares { get; set; }
        public string Permite_FamiliaresDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        
    }
}

