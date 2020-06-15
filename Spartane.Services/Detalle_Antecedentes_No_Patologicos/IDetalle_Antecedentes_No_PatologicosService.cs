using System;
using Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Antecedentes_No_Patologicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Antecedentes_No_PatologicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_PatologicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
