using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class LanguageModel
    {

        public int System_Language_Id { get; set; }

        public string Resource_File { get; set; }

        public string Language { get; set; }

        public bool Initial { get; set; }

        public int Id { get; set; }

    }
}
