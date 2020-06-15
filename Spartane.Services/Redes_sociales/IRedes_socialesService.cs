using System;
using Spartane.Core.Domain.Redes_sociales;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Redes_sociales
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRedes_socialesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Redes_sociales.Redes_sociales GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Redes_sociales.Redes_sociales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Redes_sociales.Redes_sociales entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Redes_sociales.Redes_socialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
