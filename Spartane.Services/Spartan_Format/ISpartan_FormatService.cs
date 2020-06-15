using System;
using Spartane.Core.Domain.Spartan_Format;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Format
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_FormatService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Format.Spartan_Format> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format.Spartan_Format> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format.Spartan_Format> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Format.Spartan_Format GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Format.Spartan_Format entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Format.Spartan_Format entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Format.Spartan_Format> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Format.Spartan_Format> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Format.Spartan_FormatPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Format.Spartan_Format> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
