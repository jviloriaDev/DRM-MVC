using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_SettingsAdvanceSearchModel
    {
        public Spartan_SettingsAdvanceSearchModel()
        {

        }
        public Filters ClaveFilter { set; get; }
        public string Clave { set; get; }

        public Filters ValorFilter { set; get; }
        public string Valor { set; get; }


    }
}
