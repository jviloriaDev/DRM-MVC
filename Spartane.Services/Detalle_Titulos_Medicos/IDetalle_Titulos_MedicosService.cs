using System;
using Spartane.Core.Domain.Detalle_Titulos_Medicos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Titulos_Medicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Titulos_MedicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Titulos_Medicos.Detalle_Titulos_Medicos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
