using System;
using Spartane.Core.Domain.Estado_de_Animo;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estado_de_Animo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstado_de_AnimoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estado_de_Animo.Estado_de_AnimoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
