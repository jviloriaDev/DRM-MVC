using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Common
{
    public class Spartan_File
    {
        public int FileId { get; set; }
        public string Description { get; set; }
        public Image File { get; set; }
        public int FileSize { get; set; }
        public virtual Spartan_Object Object { get; set; }
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
