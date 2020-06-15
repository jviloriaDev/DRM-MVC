using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Notice
{
    public class Spartan_Notice
    {
        public int NoticeId { get; set; }
        public string Description { get; set; }
        public Spartan_Notice_Type Type { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public virtual Spartan_Notice_Status Status { get; set; }
    }
}
