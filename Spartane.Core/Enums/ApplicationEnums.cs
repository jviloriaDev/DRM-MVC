using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Enums
{
    public enum PermissionTypes
    {
        Consult = 1,
        New = 2,
        Edit = 3,
        Delete = 4,
        Export = 5,
        Print = 6,
        Configure = 7,
    }

    public enum ModuleObjectId
    {
        EMPLEADOS_OBJECT = 1,
        EMPLEADOS_JOBHISTORY = 1004,
    }

    public enum Event_Type
    {
        Login = 1,
        LogOut = 2,
    }

    public enum Result_Type
    {
        Granted = 1,
        Denied = 2,
    }

    public enum SpartanRoleEnum
    {
        Admin = 1,
    }
}
