using System;
using Spartane.Core.Domain.Bancos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Bancos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IBancosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Bancos.Bancos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Bancos.Bancos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Bancos.Bancos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Bancos.Bancos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Bancos.Bancos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Bancos.Bancos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Bancos.Bancos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Bancos.Bancos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Bancos.BancosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Bancos.Bancos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
