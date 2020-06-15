using System;
using Spartane.Core.Domain.Estatus;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus.Estatus> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus.Estatus> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus.Estatus> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus.Estatus GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus.Estatus entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus.Estatus entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus.Estatus> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus.Estatus> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus.EstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus.Estatus> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
