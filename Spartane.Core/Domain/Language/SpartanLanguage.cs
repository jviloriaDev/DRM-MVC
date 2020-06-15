using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Language
{
    public class SpartanLanguage
    {
        public int System_Language_Id { get; set; }
        public string Resource_File { get; set; }
        public string Language { get; set; }
        public bool Initial { get; set; }
        public int Id { get; set; }
    }
}
