using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Domain.TTArchivos
{
   /// <summary>
    /// TTUsuarios table
    /// </summary>
    public class TTArchivos: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public byte[] Archivo { get; set; }
    }
}

