using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    [Serializable]
    public class UserContextViewModel : BaseModel
    {
        public ContextViewModel CurrentUser { get; set; }

        public string Password { set; get; }

        public List<string> Permisssion { get; set; }
    }
}