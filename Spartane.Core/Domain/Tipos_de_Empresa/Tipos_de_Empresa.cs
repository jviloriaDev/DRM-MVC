using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipos_de_Empresa
{
    /// <summary>
    /// Tipos_de_Empresa table
    /// </summary>
    public class Tipos_de_Empresa: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public short? Clave_Rol { get; set; }


    }
	
	public class Tipos_de_Empresa_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public short? Clave_Rol { get; set; }

		
    }


}

