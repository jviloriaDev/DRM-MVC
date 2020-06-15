using System;
using Spartane.Core.Domain.Pantalla_Francisco;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Pantalla_Francisco
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPantalla_FranciscoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Pantalla_Francisco.Pantalla_FranciscoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
