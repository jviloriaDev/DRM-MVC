using System;
using Spartane.Core.Domain.Profesiones;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Profesiones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IProfesionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Profesiones.Profesiones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Profesiones.Profesiones entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Profesiones.Profesiones entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Profesiones.Profesiones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Profesiones.ProfesionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Profesiones.Profesiones> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
