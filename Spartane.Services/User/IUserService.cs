using System;
using Spartane.Core.Domain.User;
using System.Collections.Generic;
using Spartane.Core.Domain.Data; 

namespace Spartane.Services.User
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IUserService
    {
        /// <summary>
        /// Login user with credentials
        /// </summary>
        /// <param name="sUser"></param>
        /// <param name="sPassword"></param>
        /// <param name="Language"></param>
        /// <returns></returns>
        GlobalData Login(string sUser, string sPassword, int Language);
        /// <summary>
        /// Logoff user authenticated
        /// </summary>
        /// <param name="UserInformation"></param>
        /// <returns></returns>
        bool LogOff(GlobalData UserInformation);
        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>TTUsuario</returns>
        TTUsuario GetUserByUsername(string username);
        /// <summary>
        /// Get Global Data by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>GlobalData</returns>
        GlobalData GetGlobalDataByUserName(string username);

        Int32 SelCount();
        IList<TTUsuario> SelAll(Boolean ConRelaciones);
        IList<TTUsuario> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        TTUsuario GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(TTUsuario entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(TTUsuario entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
