using System;
using Spartane.Core.Domain.Consultas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Consultas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IConsultasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Consultas.Consultas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Consultas.Consultas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Consultas.Consultas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Consultas.Consultas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Consultas.Consultas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Consultas.Consultas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Consultas.Consultas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Consultas.Consultas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Consultas.ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Consultas.Consultas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
