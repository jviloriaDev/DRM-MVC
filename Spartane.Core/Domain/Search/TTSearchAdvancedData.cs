using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Search
{
    public class TTSearchAdvancedData
    {
        public int VistaID { get; set; }
        public String Name { get; set; }
        public Boolean Default { get; set; }
        public Boolean Obligatory { get; set; }
        public Boolean Empty { get; set; }
        public int ProcessID { get; set; }
        public int UserID { get; set; }
        public String Sql { get; set; }
        public ICollection<String> UserGroups { get; set; }
        public ICollection<TTSearchAdvancedDataDetails> Details { get; set; }
    }
}
