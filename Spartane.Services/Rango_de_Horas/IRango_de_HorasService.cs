using System;
using Spartane.Core.Domain.Rango_de_Horas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Rango_de_Horas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRango_de_HorasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Rango_de_Horas.Rango_de_HorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
