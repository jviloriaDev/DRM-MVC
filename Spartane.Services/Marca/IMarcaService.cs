using System;
using Spartane.Core.Domain.Marca;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Marca
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMarcaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Marca.Marca> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Marca.Marca> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Marca.Marca> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Marca.Marca GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Marca.Marca entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Marca.Marca entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Marca.Marca> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Marca.Marca> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Marca.MarcaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Marca.Marca> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
