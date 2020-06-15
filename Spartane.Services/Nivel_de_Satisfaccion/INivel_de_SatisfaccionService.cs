using System;
using Spartane.Core.Domain.Nivel_de_Satisfaccion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Nivel_de_Satisfaccion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface INivel_de_SatisfaccionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_SatisfaccionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
