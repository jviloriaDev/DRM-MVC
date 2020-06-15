using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Archivos
{
    /// <summary>
    /// Departamento table
    /// </summary>
    public class Archivos: BaseEntity
    {
        public int Clave { get; set; }
        public string URL { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public int Length { get; set; }
        public string Nombre_Original { get; set; }

    }
}
