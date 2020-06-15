using System;
using Spartane.Core.Domain.Interpretacion_IMC;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Interpretacion_IMC
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_IMCService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
