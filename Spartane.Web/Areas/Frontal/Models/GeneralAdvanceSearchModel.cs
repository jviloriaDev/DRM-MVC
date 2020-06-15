using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spartane.Web.Areas.Frontal.Models
{
    public class GeneralAdvanceSearchModel
    {
        public GeneralAdvanceSearchModel()
        {

        }
    }

    public enum RadioOptions
    {
        Yes = 1,
        No = 0,
        NoApply = -1
    }
    public enum Filters
    {
        BeginWith = 1,
        EndWith = 2,
        Exact = 3,
        Contains = 4
    }
}
