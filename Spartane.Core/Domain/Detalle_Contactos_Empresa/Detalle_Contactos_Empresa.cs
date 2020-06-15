using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.areas_Empresas;
using Spartane.Core.Domain.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Contactos_Empresa
{
    /// <summary>
    /// Detalle_Contactos_Empresa table
    /// </summary>
    public class Detalle_Contactos_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool? Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public bool? Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool? Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Area")]
        public virtual Spartane.Core.Domain.areas_Empresas.areas_Empresas Area_areas_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }
	
	public class Detalle_Contactos_Empresa_Datos_Generales
    {
                public int Folio { get; set; }
        public int? Folio_Empresas { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool? Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public bool? Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool? Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }

		        [ForeignKey("Folio_Empresas")]
        public virtual Spartane.Core.Domain.Empresas.Empresas Folio_Empresas_Empresas { get; set; }
        [ForeignKey("Area")]
        public virtual Spartane.Core.Domain.areas_Empresas.areas_Empresas Area_areas_Empresas { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Domain.Estatus.Estatus Estatus_Estatus { get; set; }

    }


}

