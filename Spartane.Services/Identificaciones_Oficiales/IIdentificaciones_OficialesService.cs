using System;
using Spartane.Core.Domain.Identificaciones_Oficiales;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Identificaciones_Oficiales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIdentificaciones_OficialesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_OficialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
