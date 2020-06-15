using System;
using System.Collections.Generic;
using Spartane.Core.Domain.Controls;
using Spartane.Core.Domain.Filters;

namespace Spartane.Core.Domain.Search
{
    public partial class TTSearchAdvancedDataDetails
    {
        public int DNTID{ get; set; }
        public int DTID { get; set; }
        public String NombreDT{ get; set; }
        public Boolean Visible{ get; set; }
        public int Order{ get; set; }
        public String From{ get; set; }
        public String To{ get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Week { get; set; }
        public Nullable<int> Yes_Not { get; set; }
        public TypesTextFilter ConditionText { get; set; }
        public ICollection<String> ListaDependientes { get; set; }
        public TypeControlPresentation Presentation { get; set; }
        public TypeControlSearchAdvanced ControlScreenSearchAdvanced { get; set; }
    }
}
