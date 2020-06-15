using System;
using Spartane.Core.Domain.Interpretacion_Calorias;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Interpretacion_Calorias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_CaloriasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
