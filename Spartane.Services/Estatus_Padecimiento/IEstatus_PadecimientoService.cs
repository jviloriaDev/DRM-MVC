using System;
using Spartane.Core.Domain.Estatus_Padecimiento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_Padecimiento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_PadecimientoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_Padecimiento.Estatus_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
