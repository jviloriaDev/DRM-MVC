using System;
using Spartane.Core.Domain.Suplementos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Suplementos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISuplementosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Suplementos.Suplementos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Suplementos.Suplementos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Suplementos.Suplementos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Suplementos.Suplementos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Suplementos.SuplementosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Suplementos.Suplementos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
