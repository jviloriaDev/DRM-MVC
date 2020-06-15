using System;
using Spartane.Core.Domain.Motivos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Motivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMotivosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Motivos.Motivos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Motivos.Motivos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Motivos.Motivos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Motivos.Motivos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Motivos.Motivos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Motivos.Motivos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Motivos.Motivos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Motivos.Motivos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Motivos.MotivosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Motivos.Motivos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
