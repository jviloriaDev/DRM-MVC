using System;
using Spartane.Core.Domain.Resultados_IMC;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Resultados_IMC
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IResultados_IMCService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Resultados_IMC.Resultados_IMC GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Resultados_IMC.Resultados_IMC entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Resultados_IMC.Resultados_IMC entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Resultados_IMC.Resultados_IMCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
