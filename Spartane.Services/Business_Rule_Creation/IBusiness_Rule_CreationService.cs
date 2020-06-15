using System;
using Spartane.Core.Domain.Business_Rule_Creation;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Business_Rule_Creation
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IBusiness_Rule_CreationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
