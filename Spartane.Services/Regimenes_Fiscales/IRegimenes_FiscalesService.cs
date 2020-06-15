using System;
using Spartane.Core.Domain.Regimenes_Fiscales;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Regimenes_Fiscales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegimenes_FiscalesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_FiscalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
