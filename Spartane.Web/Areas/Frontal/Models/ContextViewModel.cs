using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ContextViewModel
    {
        public String UserName { get; set; }

        public int Id_User { get; set; }

        public string Name { get; set; }
        
        public int Role { get; set; }
        
        public string Email { get; set; }
        
        public int Status { get; set; }
        
        public string Password { get; set; }
        
        public int Id { get; set; }
    }
}