using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Binnacle
{
    public partial interface IBinnacleService
    {
        void InsertIntoBitacoraLog(GlobalData UserInformation, TTSecurityModeLog ModeLog);
    }
}
