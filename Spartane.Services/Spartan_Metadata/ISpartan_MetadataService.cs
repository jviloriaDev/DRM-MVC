using System;
using Spartane.Core.Domain.Spartan_Metadata;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Metadata
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_MetadataService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
