using System;
using System.Collections.Generic;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;


namespace Spartane.Services.Security
{
    /// <summary>
    /// Permission service interface
    /// </summary>
    public partial interface IPermissionService
    {
        /// <summary>
        /// return if an operation is permited to user
        /// </summary>
        /// <param name="sProcess"></param>
        /// <param name="operations"></param>
        /// <param name="UserInformation"></param>
        /// <returns></returns>
        bool isOperationPermited(int sProcess, Operations operations, GlobalData UserInformation);
        /// <summary>
        /// Return Modules permited to user
        /// </summary>
        /// <param name="UserInformation"></param>
        /// <returns></returns>
        IList<ModulesData> ModulesPermited(GlobalData UserInformation);
        /// <summary>
        /// Return dashboards permited to user
        /// </summary>
        /// <param name="UserInformation"></param>
        /// <returns></returns>
        IList<DashBoardData> DashBoardsPermited(GlobalData UserInformation);

    }
}
