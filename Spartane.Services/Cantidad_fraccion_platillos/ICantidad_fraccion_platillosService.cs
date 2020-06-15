using System;
using Spartane.Core.Domain.Cantidad_fraccion_platillos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Cantidad_fraccion_platillos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICantidad_fraccion_platillosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
