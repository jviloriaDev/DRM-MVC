using System;
using Spartane.Core.Domain.Musculos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Musculos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMusculosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Musculos.Musculos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Musculos.Musculos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Musculos.Musculos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Musculos.Musculos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Musculos.Musculos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Musculos.Musculos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Musculos.Musculos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Musculos.Musculos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Musculos.MusculosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Musculos.Musculos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
