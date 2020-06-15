using System;
using Spartane.Core.Domain.Departamento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data; 

namespace Spartane.Services.Archivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IArchivosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Archivos.Archivos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Archivos.Archivos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Archivos.Archivos GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, Spartane.Core.Domain.User.GlobalData DepartamentoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Archivos.Archivos entity, Spartane.Core.Domain.User.GlobalData DepartamentoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Archivos.Archivos entity, Spartane.Core.Domain.User.GlobalData DepartamentoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Archivos.Archivos> SelAll(Boolean ConRelaciones, string Where, string Order);
    
    }
}

