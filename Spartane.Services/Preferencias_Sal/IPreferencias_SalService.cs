using System;
using Spartane.Core.Domain.Preferencias_Sal;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Preferencias_Sal
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_SalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Preferencias_Sal.Preferencias_SalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
