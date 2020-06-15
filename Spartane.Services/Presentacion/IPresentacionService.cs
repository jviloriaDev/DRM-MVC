using System;
using Spartane.Core.Domain.Presentacion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Presentacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPresentacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Presentacion.Presentacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Presentacion.Presentacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Presentacion.Presentacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Presentacion.Presentacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Presentacion.PresentacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Presentacion.Presentacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
