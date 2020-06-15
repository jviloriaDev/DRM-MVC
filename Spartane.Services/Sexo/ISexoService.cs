using System;
using Spartane.Core.Domain.Sexo;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Sexo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISexoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Sexo.Sexo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Sexo.Sexo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Sexo.Sexo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Sexo.Sexo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Sexo.Sexo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Sexo.Sexo entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Sexo.Sexo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Sexo.Sexo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Sexo.SexoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Sexo.Sexo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
