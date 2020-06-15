using System;
using Spartane.Core.Domain.Preferencias_Grasas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Preferencias_Grasas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_GrasasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Preferencias_Grasas.Preferencias_GrasasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
