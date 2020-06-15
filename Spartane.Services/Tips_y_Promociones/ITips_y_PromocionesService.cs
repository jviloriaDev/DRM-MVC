using System;
using Spartane.Core.Domain.Tips_y_Promociones;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tips_y_Promociones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITips_y_PromocionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tips_y_Promociones.Tips_y_PromocionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
