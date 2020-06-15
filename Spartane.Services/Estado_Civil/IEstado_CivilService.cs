using System;
using Spartane.Core.Domain.Estado_Civil;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estado_Civil
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstado_CivilService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estado_Civil.Estado_Civil GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estado_Civil.Estado_Civil entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estado_Civil.Estado_Civil entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estado_Civil.Estado_CivilPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
