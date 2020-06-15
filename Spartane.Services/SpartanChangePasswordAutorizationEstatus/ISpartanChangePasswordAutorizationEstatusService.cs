using System;
using Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.SpartanChangePasswordAutorizationEstatus
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartanChangePasswordAutorizationEstatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
