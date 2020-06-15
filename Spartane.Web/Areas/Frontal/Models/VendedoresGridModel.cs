using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class VendedoresGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Nombre_de_Usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Usuario_RegistradoName { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Fecha_de_nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public string Pais_de_nacimientoNombre_del_Pais { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public string Entidad_de_nacimientoNombre_del_Estado { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public int? Banco { get; set; }
        public string BancoNombre { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Numero_de_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }
        
    }
}

