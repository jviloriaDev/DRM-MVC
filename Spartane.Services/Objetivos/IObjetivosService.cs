using System;
using Spartane.Core.Domain.Objetivos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Objetivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IObjetivosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Objetivos.Objetivos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Objetivos.Objetivos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Objetivos.Objetivos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Objetivos.Objetivos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Objetivos.ObjetivosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Objetivos.Objetivos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
