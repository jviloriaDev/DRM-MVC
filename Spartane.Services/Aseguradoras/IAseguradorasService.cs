using System;
using Spartane.Core.Domain.Aseguradoras;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Aseguradoras
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAseguradorasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Aseguradoras.Aseguradoras GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Aseguradoras.Aseguradoras entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Aseguradoras.Aseguradoras entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Aseguradoras.AseguradorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
