using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_ProcessMainModel
    {
        public Spartan_Traduction_ProcessModel Spartan_Traduction_ProcessInfo { set; get; }
        public Spartan_Traduction_Process_DataGridModelPost Spartan_Traduction_Process_DataGridInfo { set; get; }
        public Spartan_Traduction_DetailGridModelPost Spartan_Traduction_DetailGridInfo { set; get; }
        public Spartan_Traduction_Process_WorkflowGridModelPost Spartan_Traduction_Process_WorkflowGridInfo { set; get; }

    }

    public class Spartan_Traduction_Process_DataGridModelPost
    {
        public int Clave { get; set; }
        public int? Concept { get; set; }
        public string Name_of_Control { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_Traduction_DetailGridModelPost
    {
        public int IdTraductionDetail { get; set; }
        public int? Concept { get; set; }
        public int? IdConcept { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_Traduction_Process_WorkflowGridModelPost
    {
        public int Clave { get; set; }
        public int? Concept { get; set; }
        public int? ID_of_Step { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }

        public bool Removed { set; get; }
    }



}

