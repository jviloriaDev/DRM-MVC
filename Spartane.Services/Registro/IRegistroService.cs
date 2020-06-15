using System;
using Spartane.Core.Domain.Registro;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Registro
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistroService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Registro.Registro> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Registro.Registro> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Registro.Registro> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Registro.Registro GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Registro.Registro entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Registro.Registro entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Registro.Registro> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Registro.Registro> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Registro.RegistroPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Registro.Registro> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
