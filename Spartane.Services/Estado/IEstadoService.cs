using System;
using Spartane.Core.Domain.Estado;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estado
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstadoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estado.Estado> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estado.Estado> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estado.Estado> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estado.Estado GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estado.Estado entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estado.Estado entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estado.Estado> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estado.Estado> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estado.EstadoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estado.Estado> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
