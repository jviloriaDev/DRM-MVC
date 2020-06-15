using System;
using Spartane.Core.Domain.Detalle_Terapia_Hormonal;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Terapia_Hormonal
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Terapia_HormonalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_HormonalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
