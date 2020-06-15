using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Bebidas;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Preferencia_Bebidas
{
    /// <summary>
    /// Detalle_Preferencia_Bebidas table
    /// </summary>
    public class Detalle_Preferencia_Bebidas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Bebida { get; set; }
        public int? Cantidad { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Bebida")]
        public virtual Spartane.Core.Domain.Bebidas.Bebidas Bebida_Bebidas { get; set; }
        [ForeignKey("Cantidad")]
        public virtual Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas Cantidad_Rango_Consumo_Bebidas { get; set; }

    }
	
	public class Detalle_Preferencia_Bebidas_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Bebida { get; set; }
        public int? Cantidad { get; set; }

		        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Domain.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Bebida")]
        public virtual Spartane.Core.Domain.Bebidas.Bebidas Bebida_Bebidas { get; set; }
        [ForeignKey("Cantidad")]
        public virtual Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas Cantidad_Rango_Consumo_Bebidas { get; set; }

    }


}

