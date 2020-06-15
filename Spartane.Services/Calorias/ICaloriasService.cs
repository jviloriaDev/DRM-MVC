using System;
using Spartane.Core.Domain.Calorias;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Calorias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICaloriasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Calorias.Calorias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Calorias.Calorias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Calorias.Calorias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Calorias.Calorias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Calorias.Calorias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Calorias.Calorias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Calorias.Calorias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Calorias.Calorias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Calorias.CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Calorias.Calorias> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
