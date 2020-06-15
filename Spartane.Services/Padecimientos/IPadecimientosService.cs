using System;
using Spartane.Core.Domain.Padecimientos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Padecimientos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPadecimientosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Padecimientos.Padecimientos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Padecimientos.Padecimientos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Padecimientos.Padecimientos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Padecimientos.Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Padecimientos.PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Padecimientos.Padecimientos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
