using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlowMainModel
    {
        public Spartan_WorkFlowModel Spartan_WorkFlowInfo { set; get; }
        public Spartan_WorkFlow_PhasesGridModelPost Spartan_WorkFlow_PhasesGridInfo { set; get; }
        public Spartan_WorkFlow_StateGridModelPost Spartan_WorkFlow_StateGridInfo { set; get; }
        public Spartan_WorkFlow_Conditions_by_StateGridModelPost Spartan_WorkFlow_Conditions_by_StateGridInfo { set; get; }
        public Spartan_WorkFlow_Information_by_StateGridModelPost Spartan_WorkFlow_Information_by_StateGridInfo { set; get; }
        public Spartan_WorkFlow_Roles_by_StateGridModelPost Spartan_WorkFlow_Roles_by_StateGridInfo { set; get; }
        public Spartan_WorkFlow_Matrix_of_StatesGridModelPost Spartan_WorkFlow_Matrix_of_StatesGridInfo { set; get; }

    }

    public class Spartan_WorkFlow_PhasesGridModelPost
    {
        public int PhasesId { get; set; }
        public short? Phase_Number { get; set; }
        public string Name { get; set; }
        public short? Phase_Type { get; set; }
        public short? Type_of_Work_Distribution { get; set; }
        public short? Type_Flow_Control { get; set; }
        public short? Phase_Status { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_WorkFlow_StateGridModelPost
    {
        public int StateId { get; set; }
        public int? Phase { get; set; }
        public int? Attribute { get; set; }
        public int? State_Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }
        public string Text { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_WorkFlow_Conditions_by_StateGridModelPost
    {
        public int Conditions_by_StateId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public int? Condition_Operator { get; set; }
        public int? Attribute { get; set; }
        public short? Condition { get; set; }
        public short? Operator { get; set; }
        public string Operator_Value { get; set; }
        public short? Priority { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_WorkFlow_Information_by_StateGridModelPost
    {
        public int Information_by_StateId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public int? Folder { get; set; }
        public bool? Visible { get; set; }
        public bool? Read_Only { get; set; }
        public bool? Required { get; set; }
        public string Label { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_WorkFlow_Roles_by_StateGridModelPost
    {
        public int Roles_by_StateId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public short? User_Role { get; set; }
        public short? Phase_Transition { get; set; }
        public bool? Permission_To_Consult { get; set; }
        public bool? Permission_To_New { get; set; }
        public bool? Permission_To_Modify { get; set; }
        public bool? Permission_to_Delete { get; set; }
        public bool? Permission_To_Export { get; set; }
        public bool? Permission_To_Print { get; set; }
        public bool? Permission_Settings { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_WorkFlow_Matrix_of_StatesGridModelPost
    {
        public int Matrix_of_StatesId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public int? Attribute { get; set; }
        public bool? Visible { get; set; }
        public bool? Required { get; set; }
        public bool? Read_Only { get; set; }
        public string Label { get; set; }
        public string Default_Value { get; set; }
        public string Help_Text { get; set; }

        public bool Removed { set; get; }
    }



}

