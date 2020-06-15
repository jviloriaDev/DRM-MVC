using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_User_Historical_PasswordGridModel
    {
        public int Clave { get; set; }
        public string Fecha_de_Registro { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Password { get; set; }
        
    }
}

