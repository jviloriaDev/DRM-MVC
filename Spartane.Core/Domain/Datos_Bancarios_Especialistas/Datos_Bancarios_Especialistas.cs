using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Bancos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Datos_Bancarios_Especialistas
{
    /// <summary>
    /// Datos_Bancarios_Especialistas table
    /// </summary>
    public class Datos_Bancarios_Especialistas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public int? Banco { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Num_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public bool? Principal { get; set; }

        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Banco")]
        public virtual Spartane.Core.Domain.Bancos.Bancos Banco_Bancos { get; set; }

    }
	
	public class Datos_Bancarios_Especialistas_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public int? Banco { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Num_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }
        public bool? Principal { get; set; }

		        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Domain.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Banco")]
        public virtual Spartane.Core.Domain.Bancos.Bancos Banco_Bancos { get; set; }

    }


}

