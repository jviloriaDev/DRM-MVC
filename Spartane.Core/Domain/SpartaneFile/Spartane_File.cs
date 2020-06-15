using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.SpartaneFile
{
    /// <summary>
    /// Spartane_File table
    /// </summary>
    public class Spartane_File : BaseEntity
    {
        /*public long File_Id { get; set; }
        public string File_Name { get; set; }
        public long File_Size { get; set; }
        public byte[] File { get; set; }  */

        public int File_Id { get; set; }
        public string Description { get; set; }
        public int? File1 { get; set; }
        public int? File_Size { get; set; }
        public int? Object { get; set; }
        public int? User_Id { get; set; }
        public DateTime? Date_Time { get; set; }
        public byte[] File { set; get; }

        public virtual Spartane.Core.Domain.TTArchivos.TTArchivos File1_TTArchivos { get; set; }
    }
}
