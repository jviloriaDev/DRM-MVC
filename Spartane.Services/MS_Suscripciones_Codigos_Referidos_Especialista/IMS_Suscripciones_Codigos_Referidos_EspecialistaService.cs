using System;
using Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.MS_Suscripciones_Codigos_Referidos_Especialista
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_Suscripciones_Codigos_Referidos_EspecialistaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
