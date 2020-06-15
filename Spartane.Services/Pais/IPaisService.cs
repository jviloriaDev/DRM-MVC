using System;
using Spartane.Core.Domain.Pais;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Pais
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPaisService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Pais.Pais> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Pais.Pais> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Pais.Pais> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Pais.Pais GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Pais.Pais entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Pais.Pais entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Pais.Pais> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Pais.Pais> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Pais.PaisPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Pais.Pais> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
