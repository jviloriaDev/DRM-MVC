using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class SideBar
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string IconClass { get; set; }
        public int? Orden { get; set; }
        public string Tabs { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Controller { get; set; }
        public List<SideBar> Opciones { get; set; }
    }

}