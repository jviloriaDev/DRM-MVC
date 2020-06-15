using System;
using Spartane.Core.Domain.Respuesta_Logica;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Respuesta_Logica
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRespuesta_LogicaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Respuesta_Logica.Respuesta_LogicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
