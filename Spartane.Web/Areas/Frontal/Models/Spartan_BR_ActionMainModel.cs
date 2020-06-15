using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_ActionMainModel
    {
        public Spartan_BR_ActionModel Spartan_BR_ActionInfo { set; get; }
        public Spartan_BR_Action_Configuration_DetailGridModelPost Spartan_BR_Action_Configuration_DetailGridInfo { set; get; }
        public Spartan_BR_Attribute_Restrictions_DetailGridModelPost Spartan_BR_Attribute_Restrictions_DetailGridInfo { set; get; }
        public Spartan_BR_Operation_Restrictions_DetailGridModelPost Spartan_BR_Operation_Restrictions_DetailGridInfo { set; get; }
        public Spartan_BR_Event_Restrictions_DetailGridModelPost Spartan_BR_Event_Restrictions_DetailGridInfo { set; get; }

    }

    public class Spartan_BR_Action_Configuration_DetailGridModelPost
    {
        public int ActionConfigurationId { get; set; }
        public string Parameter_Name { get; set; }
        public int? Parameter_Type { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Attribute_Restrictions_DetailGridModelPost
    {
        public int RestrictionId { get; set; }
        public int? Attribute_Type { get; set; }
        public short? Control_Type { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Operation_Restrictions_DetailGridModelPost
    {
        public int RestrictionId { get; set; }
        public short? Operation { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Event_Restrictions_DetailGridModelPost
    {
        public int RestrictionId { get; set; }
        public short? Process_Event { get; set; }

        public bool Removed { set; get; }
    }



}

