using System;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Action_Classification
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Action_ClassificationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
