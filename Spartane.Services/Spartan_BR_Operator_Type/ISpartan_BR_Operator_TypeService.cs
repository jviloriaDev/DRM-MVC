using System;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Operator_Type
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Operator_TypeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
