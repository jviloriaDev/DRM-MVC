using System;
using Spartane.Core.Domain.Preferencias_Entrecomidas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Preferencias_Entrecomidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPreferencias_EntrecomidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_EntrecomidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
