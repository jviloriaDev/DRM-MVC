using System;
using Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Identificacion_Oficial_Medicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Identificacion_Oficial_MedicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
