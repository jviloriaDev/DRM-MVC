using System;
using Spartane.Core.Domain.Parentesco;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Parentesco
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IParentescoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Parentesco.Parentesco GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Parentesco.Parentesco entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Parentesco.Parentesco entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Parentesco.Parentesco> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Parentesco.ParentescoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Parentesco.Parentesco> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
