using System;
using Spartane.Core.Domain.Spartan_Format_Configuration;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Format_Configuration
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_ConfigurationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_ConfigurationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
