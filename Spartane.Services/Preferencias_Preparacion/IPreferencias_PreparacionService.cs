using System;
using Spartane.Core.Domain.Preferencias_Preparacion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Preferencias_Preparacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_PreparacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_PreparacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
